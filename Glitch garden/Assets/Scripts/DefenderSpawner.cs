using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defender;
    private StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    private void OnMouseDown()
    {
        if (!defender) return;
        SpawnDefender(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }

    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        float newX = Mathf.Round(worldPos.x) + defender.GetOffset().x;
        float newY = Mathf.Round(worldPos.y) + defender.GetOffset().y;
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 spawnPos)
    {
        if (!starDisplay.HaveEnoughStars(defender.GetStarCost())) return;
        starDisplay.SpendStars(defender.GetStarCost());
        var newDefender = Instantiate(defender, spawnPos, Quaternion.identity);
    }

    public void SetSelectedDefender(Defender defender)
    {
        this.defender = defender;
    }
}

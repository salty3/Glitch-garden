using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defender;
    private StarDisplay starDisplay;
    private GameObject defenderParent;
    private const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
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
        float newX = Mathf.Round(worldPos.x);
        float newY = Mathf.Round(worldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 spawnPos)
    {
        if (!starDisplay.HaveEnoughStars(defender.GetStarCost())) return;
        starDisplay.SpendStars(defender.GetStarCost());
        var newDefender = Instantiate(defender, spawnPos, Quaternion.identity);
        newDefender.transform.parent = defenderParent.transform;
    }

    public void SetSelectedDefender(Defender defender)
    {
        this.defender = defender;
    }
}

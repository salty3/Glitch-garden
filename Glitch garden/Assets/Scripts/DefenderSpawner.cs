using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private GameObject defender;
    [SerializeField] private float xOffset, yOffset;

    private void OnMouseDown()
    {
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
        float newX = Mathf.Round(worldPos.x) + xOffset;
        float newY = Mathf.Round(worldPos.y) + yOffset;
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 spawnPos)
    {
        var newDefender = Instantiate(defender, spawnPos, Quaternion.identity);
    }
}

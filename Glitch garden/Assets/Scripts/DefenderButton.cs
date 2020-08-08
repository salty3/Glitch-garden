using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] private Defender defenderPrefab;
    private DefenderButton[] buttons;
    private DefenderSpawner defenderSpawner;

    private void Start()
    {
        buttons = FindObjectsOfType<DefenderButton>();
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }

    private void OnMouseDown()
    {
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(84, 84, 84, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;

        defenderSpawner.SetSelectedDefender(defenderPrefab);
    }
}

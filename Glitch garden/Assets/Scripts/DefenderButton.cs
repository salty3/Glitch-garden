using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] private Defender defenderPrefab;
    private DefenderButton[] buttons;
    private DefenderSpawner defenderSpawner;

    private void Start()
    {
        buttons = FindObjectsOfType<DefenderButton>();
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        costText.text = defenderPrefab.GetStarCost().ToString();
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

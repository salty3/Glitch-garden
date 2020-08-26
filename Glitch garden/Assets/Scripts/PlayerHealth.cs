using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private LevelController levelController;
    private Text healthText;
    
    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }
    
    public void DecreaseHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            levelController.Lose();
        }
        UpdateDisplay();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private int healthDecrease = 1;

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerHealth.DecreaseHealth(healthDecrease);
        Destroy(other.gameObject);
    }

    public int HealthDecrease
    {
        get => healthDecrease;
        set => healthDecrease = value >= 1 ? value : 1;
    }
}

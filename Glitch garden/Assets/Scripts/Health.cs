using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private ParticleSystem deathVFX;

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        TriggerDeathVFX();
        Destroy(gameObject);
    }

    private void TriggerDeathVFX()
    {
        var vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(vfx, 1f);
    }
}

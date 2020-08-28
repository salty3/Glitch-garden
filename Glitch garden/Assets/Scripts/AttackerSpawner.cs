using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private Attacker[] enemies;
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private bool spawn = true;

    private IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }
    public void StopSpawning()
    {
        spawn = false;
    }
    private void SpawnAttacker()
    {
        Spawn(Random.Range(0, enemies.Length));
    }

    private void Spawn(int enemyIndex)
    {
        Attacker newAttacker = Instantiate(enemies[enemyIndex], transform.position, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }

    public float MinSpawnDelay
    {
        get => minSpawnDelay;
        set => minSpawnDelay = value >= 0f ? value : 1f;
    }
    
    public float MaxSpawnDelay
    {
        get => maxSpawnDelay;
        set => maxSpawnDelay = value >= 0f ? value : 1f;
    }
}

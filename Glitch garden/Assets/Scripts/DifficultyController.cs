using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    [Header("Easy")]
    [SerializeField] private int easyHealth = 8;
    [SerializeField] private float easySpawnDelayMultiplier = 2f;
    [SerializeField] private int easyHealthDecrease = 1;
    [SerializeField] private float easyLevelTimeMultiplier = 3f;
    [Header("Medium")]
    [SerializeField] private int mediumHealth = 6;
    [SerializeField] private float mediumSpawnDelayMultiplier = 1f;
    [SerializeField] private int mediumHealthDecrease = 2;
    [SerializeField] private float mediumLevelTimeMultiplier = 1.5f;
    [Header("Hard")]
    [SerializeField] private int hardHealth = 3;
    [SerializeField] private float hardSpawnDelayMultiplier = 0.5f;
    [SerializeField] private int hardHealthDecrease = 3;
    [SerializeField] private float hardLevelTimeMultiplier = 0.8f;
    
    private PlayerHealth player;
    private AttackerSpawner[] attackerSpawners;
    private Base basement;
    private GameTimer gameTimer;


    private void Awake()
    {
        CacheReferences();
        SetLevelDifficulty();
    }

    private void SetLevelDifficulty()
    {
        switch (PlayerPrefsController.GetDifficulty())
        {
            case 1f:
            {
                SetDifficultyValues(
                    easyHealth,
                    easySpawnDelayMultiplier,
                    easyHealthDecrease,
                    easyLevelTimeMultiplier);
                break;
            }
            case 2f:
            {
                SetDifficultyValues(
                    mediumHealth,
                    mediumSpawnDelayMultiplier,
                    mediumHealthDecrease,
                    mediumLevelTimeMultiplier);
                break;
            }
            case 3f:
            {
                SetDifficultyValues(
                    hardHealth,
                    hardSpawnDelayMultiplier,
                    hardHealthDecrease,
                    hardLevelTimeMultiplier);
                break;
            }
        }
    }

    private void CacheReferences()
    {
        player = FindObjectOfType<PlayerHealth>();
        attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        basement = FindObjectOfType<Base>();
        gameTimer = FindObjectOfType<GameTimer>();
    }

    private void SetDifficultyValues(
        int playerHealth, 
        float spawnDelayMultiplier,
        int healthDecrease,
        float levelTimeMultiplier)
    {
        player.Health = playerHealth;
        basement.HealthDecrease = healthDecrease;
        gameTimer.LevelTime *= levelTimeMultiplier;
        foreach (var spawner in attackerSpawners)
        {
            spawner.MinSpawnDelay *= spawnDelayMultiplier;
            spawner.MaxSpawnDelay *= spawnDelayMultiplier;
        }
    }
    
}

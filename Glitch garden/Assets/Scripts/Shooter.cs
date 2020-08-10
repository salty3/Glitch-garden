using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private GameObject gun;

    private AttackerSpawner[] attackerSpawners;
    private AttackerSpawner myLaneSpawner;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }
    
    private void Update()
    {
        animator.SetBool("isAttacking", IsAttackerInLine());
    }

    private bool IsAttackerInLine()
    {
        return myLaneSpawner.transform.childCount > 0;
    }
    
    private void SetLaneSpawner()
    {
        attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (var spawner in attackerSpawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }
    
    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
}

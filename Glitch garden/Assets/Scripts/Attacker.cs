using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    //[SerializeField] private int starValue = 100;
    
    private float currentSpeed = 0f;
    private GameObject currentTarget;
    private Animator animator;
    private LevelController levelController;


    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
        levelController.AttackerSpawned();
    }
    private void OnDestroy()
    {
        if (levelController)
        {
            levelController.AttackerKilled();
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * (currentSpeed * Time.deltaTime));
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
            return;
        }
        
        var health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}

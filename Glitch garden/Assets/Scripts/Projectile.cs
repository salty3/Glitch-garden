using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed, rotationSpeed;
    [SerializeField] private int damage = 100;

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        var attacker = collision.GetComponent<Attacker>();
        if (health && attacker)
        {
            health.DealDamage(damage);
        }
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }

    
}

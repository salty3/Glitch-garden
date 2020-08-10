using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int starValue = 100;
    private float currentSpeed = 0f;

    private void Update()
    {
        transform.Translate(Vector2.left * (currentSpeed * Time.deltaTime));
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
}

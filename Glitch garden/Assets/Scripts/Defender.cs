using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int starCost = 100;
    [SerializeField] private Vector2 offset;

    public Vector2 GetOffset() { return offset; }

    public int GetStarCost()
    {
        return starCost;
    }
    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }
}

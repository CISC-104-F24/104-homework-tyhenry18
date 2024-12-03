using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    public void IncreaseHealth(int amount)
    {
        health += amount;
        Debug.Log("Player Health: " + health);
    }

    // You can also create methods to decrease health if needed
    public void DecreaseHealth(int amount)
    {
        health -= amount;
        Debug.Log("Player Health: " + health);
    }
}


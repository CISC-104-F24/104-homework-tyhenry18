using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTrigger : MonoBehaviour
{
    public int healthBoost = 20;

    // Called when the player enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Increase the player's health
            other.GetComponent<PlayerHealth>().IncreaseHealth(healthBoost);
            Debug.Log("Player gained health: " + healthBoost);

            // Deactivate the power-up object after use
            gameObject.SetActive(false);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerHandler : MonoBehaviour
{
    public float speedMultiplier = 2f;
    public float boostDuration = 3f;

    private float originalSpeed = 5f; // Example speed value
    private float currentSpeed;
    private bool isBoosted = false;

    private void Start()
    {
        currentSpeed = originalSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player enters a trigger volume tagged "SpeedBoostZone"
        if (other.CompareTag("SpeedBoostZone"))
        {
            if (!isBoosted)
            {
                StartCoroutine(ApplySpeedBoost());
                Debug.Log("Entered Speed Boost Zone!");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // While staying in a zone tagged "HealingZone", increase player health
        if (other.CompareTag("HealingZone"))
        {
            Debug.Log("Healing while in the Healing Zone...");
            // Add health logic here, e.g., increase a health variable over time
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the player exits a trigger volume tagged "DangerZone"
        if (other.CompareTag("DangerZone"))
        {
            Debug.Log("Exited the Danger Zone!");
        }
    }

    private System.Collections.IEnumerator ApplySpeedBoost()
    {
        isBoosted = true;
        currentSpeed *= speedMultiplier;
        yield return new WaitForSeconds(boostDuration);
        currentSpeed = originalSpeed;
        isBoosted = false;
        Debug.Log("Speed boost ended.");
    }
}

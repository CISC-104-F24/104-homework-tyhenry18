using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    // Called when another object enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the obstacle upon collision with the player
            Destroy(gameObject);
            Debug.Log("Obstacle destroyed upon collision with player.");
        }
    }

    // Called while the player is still within the trigger zone
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Optionally, make the obstacle change color while the player stays in range
            GetComponent<MeshRenderer>().material.color = Color.yellow;
            Debug.Log("Obstacle in trigger zone with player.");
        }
    }

    // Called when the player exits the trigger zone
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Optionally reset the color once the player leaves the trigger zone
            GetComponent<MeshRenderer>().material.color = Color.white;
            Debug.Log("Player exited the trigger zone.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeOnTag : MonoBehaviour
{
    [SerializeField] private string targetTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the specified tag
        if (other.CompareTag(targetTag))
        {
            // Attempt to find the Renderer component in the player object
            Renderer playerRenderer = other.GetComponent<Renderer>();

            // If Renderer is found, change its material color
            if (playerRenderer != null)
            {
                // Generate a random color
                Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                playerRenderer.material.color = randomColor;
            }
            else
            {
                Debug.LogWarning("The object with the specified tag does not have a Renderer component.");
            }
        }
    }
}

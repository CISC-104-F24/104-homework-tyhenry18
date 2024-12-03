using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneHandler : MonoBehaviour
{
    public Color triggerEnterColor = Color.green;
    public Color triggerExitColor = Color.white;

    private Renderer objectRenderer;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Change color when an object tagged "Player" enters the trigger
        if (other.CompareTag("Player"))
        {
            objectRenderer.material.color = triggerEnterColor;
            Debug.Log($"{other.name} entered the trigger zone.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Log a message while the object is within the trigger zone
        if (other.CompareTag("Player"))
        {
            Debug.Log($"{other.name} is still inside the trigger zone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset color when the object leaves the trigger zone
        if (other.CompareTag("Player"))
        {
            objectRenderer.material.color = triggerExitColor;
            Debug.Log($"{other.name} exited the trigger zone.");
        }
    }
}

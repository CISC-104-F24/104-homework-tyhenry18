using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    [SerializeField] private string triggeringTag = "Player";

    // Called when an object enters the trigger volume
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggeringTag))
        {
            Debug.Log(gameObject.name + " - Player Entered the Trigger!");
            DoEnterAction();
        }
    }

    // Called once per frame while an object stays inside the trigger volume
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(triggeringTag))
        {
            Debug.Log(gameObject.name + " - Player is inside the Trigger.");
            DoStayAction();
        }
    }

    // Called when an object exits the trigger volume
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggeringTag))
        {
            Debug.Log(gameObject.name + " - Player Exited the Trigger.");
            DoExitAction();
        }
    }

    // Actions for entering the trigger
    private void DoEnterAction()
    {
        // Example action: Change color of the trigger object
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.green;
        }
    }

    // Actions for staying in the trigger
    private void DoStayAction()
    {
        // Example action: Rotate the object
        transform.Rotate(Vector3.up * 20f * Time.deltaTime);
    }

    // Actions for exiting the trigger
    private void DoExitAction()
    {
        // Example action: Reset color of the trigger object
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.red;
        }
    }
}

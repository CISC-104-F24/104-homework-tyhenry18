using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObjectCollision : MonoBehaviour
{
    public float bounceForce = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        // Apply a bounce force when the object hits something
        if (collision.gameObject.CompareTag("BounceSurface"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 bounceDirection = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
            Debug.Log("Bounced off a surface!");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Gradually slow down while in contact with an object
        if (collision.gameObject.CompareTag("StickySurface"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity *= 0.9f; // Reduce speed
            Debug.Log("Slowing down on sticky surface.");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Log when the object leaves a collision
        Debug.Log($"Dynamic object exited collision with {collision.gameObject.name}");
    }
}

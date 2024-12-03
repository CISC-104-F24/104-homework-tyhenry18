using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public float bounceForce = 10f;

    // Called when a collision begins
    void OnCollisionEnter(Collision collision)
    {
        // Apply a bounce force when the ball hits something
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }

        // Change the color of the ball when colliding with an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            Debug.Log("Ball hit an obstacle, color changed to red");
        }
    }

    // Called while still colliding
    void OnCollisionStay(Collision collision)
    {
        // Optionally, implement behavior while the ball stays in contact with an object
    }

    // Called when collision ends
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Ball exited collision with obstacle");
        }
    }
}

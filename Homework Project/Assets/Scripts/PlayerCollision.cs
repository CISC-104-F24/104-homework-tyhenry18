using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public float speed = 5f;
    public int health = 100;

    // Called when a collision begins
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SpeedBoost"))
        {
            speed += 5;
            Debug.Log("Speed Boost Activated! New Speed: " + speed);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
            Debug.Log("Player took damage! Health: " + health);
        }
    }

    // Called while still colliding
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 1; // Slowly lose health while colliding with an enemy
            Debug.Log("Player still in enemy range, taking damage");
        }
    }

    // Called when collision ends
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("SpeedBoost"))
        {
            Debug.Log("Speed Boost lost");
        }
    }
}

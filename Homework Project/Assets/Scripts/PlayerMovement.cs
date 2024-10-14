using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float originalSpeed = 5f;               // Normal movement speed
    public float sprintSpeed = 8f;                 // Faster sprint speed
    public float currentSpeed;                      // Variable to track the current speed

    public float originalJumpPower = 5f;           // Default jump power
    public float powerGainedPerSecond = 2f;        // Power gained every second while charging
    public float currentJumpPower;                  // The current jump power, increases when charging

    public float rotationSpeed = 100f;              // Speed at which the player rotates
    public float scaleSpeed = 0.1f;                 // Speed of scaling up or down
    public float maxScale = 3f;                     // Maximum scale of the character
    public float minScale = 0.5f;                   // Minimum scale of the character

    private bool isGrounded = true;                 // Check if the player is on the ground
    private Rigidbody myRb;                         // The Rigidbody attached to the player

    void Start()
    {
        // Get the Rigidbody component
        myRb = GetComponent<Rigidbody>();

        // Initialize speed and jump power
        currentSpeed = originalSpeed;
        currentJumpPower = originalJumpPower;
    }

    void Update()
    {
        // Handle movement
        MovePlayer();

        // Handle jumping and charging
        HandleJump();

        // Handle rotation
        HandleRotation();

        // Handle scaling
        HandleScaling();
    }

    void MovePlayer()
    {
        // Get input for movement (WASD or Arrow keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Handle sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;  // Sprint speed while Left Shift is held
        }
        else
        {
            currentSpeed = originalSpeed; // Normal speed when not sprinting
        }

        // Create movement vector and move the player
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        myRb.MovePosition(transform.position + movement * currentSpeed * Time.deltaTime);
    }

    void HandleJump()
    {
        // Handle charged jump
        if (Input.GetKey(KeyCode.LeftControl))
        {
            // Increase the jump power gradually while Left Control is held
            currentJumpPower += powerGainedPerSecond * Time.deltaTime;
        }
        else
        {
            // Reset jump power to original if Left Control isn't pressed
            currentJumpPower = originalJumpPower;
        }

        // Perform the jump when Spacebar is pressed, using the charged jump power
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply force to jump with the current jump power
        myRb.AddForce(Vector3.up * currentJumpPower, ForceMode.Impulse);
        isGrounded = false;  // Prevent jumping again until grounded
        currentJumpPower = originalJumpPower;  // Reset jump power after jumping
    }

    void OnCollisionEnter(Collision collision)
    {
        // If the player touches the ground, allow jumping again
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void HandleRotation()
    {
        // Rotate left when Q is pressed
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        // Rotate right when E is pressed
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    void HandleScaling()
    {
        // Grow the character when "1" is pressed
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Vector3 newScale = transform.localScale + Vector3.one * scaleSpeed * Time.deltaTime;
            // Clamp the scale to the maximum value
            newScale = new Vector3(Mathf.Min(newScale.x, maxScale), Mathf.Min(newScale.y, maxScale), Mathf.Min(newScale.z, maxScale));
            transform.localScale = newScale;
        }

        // Shrink the character when "2" is pressed
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Vector3 newScale = transform.localScale - Vector3.one * scaleSpeed * Time.deltaTime;
            // Clamp the scale to the minimum value
            newScale = new Vector3(Mathf.Max(newScale.x, minScale), Mathf.Max(newScale.y, minScale), Mathf.Max(newScale.z, minScale));
            transform.localScale = newScale;
        }
    }
}
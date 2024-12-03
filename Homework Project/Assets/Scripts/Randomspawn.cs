using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomObjectRandomly : MonoBehaviour
{
    // Array to hold the prefabs of objects to spawn
    [SerializeField] private GameObject[] objectsToSpawn;

    // The tag of the object that triggers the collision
    [SerializeField] private string triggeringTag = "Player";

    // Boundaries for random spawn positions
    [SerializeField] private Vector3 minSpawnPosition; // Minimum X, Y, Z
    [SerializeField] private Vector3 maxSpawnPosition; // Maximum X, Y, Z

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the correct tag
        if (collision.gameObject.CompareTag(triggeringTag))
        {
            SpawnRandomObjectAtRandomPosition();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object has the correct tag
        if (other.CompareTag(triggeringTag))
        {
            SpawnRandomObjectAtRandomPosition();
        }
    }

    private void SpawnRandomObjectAtRandomPosition()
    {
        // Ensure there are objects to spawn
        if (objectsToSpawn.Length == 0)
        {
            Debug.LogWarning("No objects set to spawn!");
            return;
        }

        // Pick a random prefab from the list
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject randomObject = objectsToSpawn[randomIndex];

        // Generate a random position within the specified boundaries
        Vector3 randomPosition = new Vector3(
            Random.Range(minSpawnPosition.x, maxSpawnPosition.x),
            Random.Range(minSpawnPosition.y, maxSpawnPosition.y),
            Random.Range(minSpawnPosition.z, maxSpawnPosition.z)
        );

        // Instantiate the random object at the random position
        Instantiate(randomObject, randomPosition, Quaternion.identity);
    }
}

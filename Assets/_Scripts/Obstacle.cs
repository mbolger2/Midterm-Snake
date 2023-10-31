using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Collision Detection")]
    // The tag that must be on the other object
    public string collisionTag = "Projectile";

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug statement
        Debug.Log("Collided with object " + other.gameObject.name);

        // The projectile collides with the goal
        if (other.CompareTag(collisionTag))
        {
            // Remove the obstacle
            Destroy(this.gameObject);

            // Set the spawnCounter on the obstacle
            // script to decrement by 1
            // ObstacleSpawn.Instance.spawnCounter--;

        }
    }
}

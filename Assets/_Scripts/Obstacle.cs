using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    [Header("Collision Detection")]
    // The tag that must be on the other object
    public string projTag = "Projectile";
    // The tag that must be on the other object
    public string playerTag = "Player";

    // The scene that comes when the player loses
    public string lossScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug statement
        Debug.Log("Collided with object " + other.gameObject.name);

        // The projectile collides with the goal
        if (other.CompareTag(projTag))
        {
            // Set the spawnCounter on the obstacle
            // script to decrement by 1
            ObstacleSpawn.Instance.DecreaseObstacle();

            // Remove the obstacle
            Destroy(this.gameObject);

        }

        if (other.CompareTag(playerTag))
        {
            // End the game
            SceneManager.LoadScene(lossScene);
        }
    }
}

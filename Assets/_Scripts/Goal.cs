using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [Header("Collision Detection")]
    // The tag that must be on the other object
    public string scoringTag = "Player";

    BoxCollider2D headCollider;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Collided with object " + other.gameObject.name);

        // The player collides with the goal
        if (other.CompareTag(scoringTag))
        {            
            // Increase the score
            ScoreManager.Instance.AddScore(1);

            headCollider = other.gameObject.GetComponent<BoxCollider2D>();
            headCollider.isTrigger = false;

            // remove the goal
            Destroy(this.gameObject);

            // Set the count of goals to 0
            GoalSpawn.Instance.SetGoalSpawnCounter(0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [Header("Collision Detection")]
    // The tag that must be on the other object
    public string scoringTag = "Player";

  
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with object " + other.gameObject.name);

        // The player collides with the goal
        if (other.CompareTag(scoringTag))
        {
            // remove the goal
            Destroy(this.gameObject);

            // Set the count of goals to 0
            // Ask in class or in AAC

            // Increase the score
            ScoreManager.Instance.AddScore(1);

        }
    }
}

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

        if (other.CompareTag(scoringTag))
        {
            Destroy(this.gameObject);

            // GoalSpawn.
        }
    }
}

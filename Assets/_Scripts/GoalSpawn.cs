using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawn : MonoBehaviour
{
    // The prefab with the goal will be instantiated
    public Transform goalPrefab;

    // Defining an array to hold the possible spawn points
    public GameObject[] spawnPoints = new GameObject[81];

    // A counter that holds the number of goals spawned
    public int spawnCounter = 0;

    // A global variable to help spawn goals
    //static int tempSpawnCounter = 0;

    // Update is called once per frame
    void Update()
    {
        // If the counter has surpassed rate
        if (spawnCounter < 1)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);

            // Message to know where spawn
            Debug.Log("Spawning goal at " + spawnPoints[randomIndex].name);

            // Spawn the goal prefab at the position of the randomly selected
            // spawnpoint
            Instantiate(goalPrefab, spawnPoints[randomIndex].transform);

            // Reset spawn counter
            spawnCounter = 1;
            // tempSpawnCounter = 1;
        }
    }
}

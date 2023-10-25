using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawn : MonoBehaviour
{
    // The prefab with the goal will be instantiated
    public Transform goalPrefab;

    // Defining an array to hold the possible spawn points
    public GameObject[] spawnPoints = new GameObject[81];

    // The seconds between the instantiation of each goal
    public float spawnRate = 1.0f;

    // A counter
    private float spawnCounter = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        spawnCounter += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        // The delta time is added to keep track of time
        spawnCounter += Time.deltaTime;

        // If the counter has surpassed rate
        if (spawnCounter > spawnRate)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);

            // Message to know where spawn
            Debug.Log("Spawning goal at " + spawnPoints[randomIndex].name);

            // Spawn the goal prefab at the position of the randomly selected
            // spawnpoint
            Instantiate(goalPrefab);

            // Reset spawn counter
            spawnCounter = 0.0f;
        }
    }
}

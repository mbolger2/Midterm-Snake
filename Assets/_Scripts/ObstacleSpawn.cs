using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    // The prefab with the goal will be instantiated
    public Transform obstaclePrefab;

    // Defining an array to hold the possible spawn points
    public GameObject[] spawnPoints = new GameObject[81];

    // A counter that holds the number of goals spawned
    public int spawnCounter = 0;

    // Set the instance
    public static ObstacleSpawn Instance;

    public void SpawnObstacle()
    {
        
        // If the counter has surpassed rate
        if (spawnCounter < 2)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);

            // Message to know where spawn
            Debug.Log("Spawning obstacle at " + spawnPoints[randomIndex].name);

            // Spawn the goal prefab at the position of the randomly selected
            // spawnpoint
            Instantiate(obstaclePrefab, spawnPoints[randomIndex].transform);

            // Increment up by 1
            spawnCounter++;
        }
    }

    public void DecreaseObstacle()
    {
        spawnCounter--;
    }

    private void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // Call the SpawnObstacle Function
        SpawnObstacle();
        
    }
}

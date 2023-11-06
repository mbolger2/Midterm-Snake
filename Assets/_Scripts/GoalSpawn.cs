using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawn : MonoBehaviour
{
    // The prefab with the goal will be instantiated
    public Transform goalPrefab;
    public Transform obstaclePrefab;

    // Defining an array to hold the possible spawn points
    public GameObject[] spawnPoints = new GameObject[81];

    // A counter that holds the number of goals spawned
    public int goalCounter = 0;

    public int obstacleCounter = 0;

    public static GoalSpawn Instance;

    public void SetGoalSpawnCounter(int temp)
    {
        goalCounter = temp;
    }

    public void SetObstacleSpawnCounter(int temp)
    {
        obstacleCounter = temp;
    }

    private void Start()
    {
        Instance = this;
    }

    int RandNumGen()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        return randomIndex;
    }

    // Update is called once per frame
    void Update()
    {
        // If the counter has surpassed rate
        if (goalCounter < 1)
        {
            // Spawn the goal prefab at the position of the randomly selected
            // spawnpoint
            Instantiate(goalPrefab, spawnPoints[RandNumGen()].transform);
         
            // Set spawn counter
            goalCounter ++;
        }

        if (obstacleCounter < 1)
        {
            // Spawn obstacle prefab at the position randomly selected
            Instantiate(obstaclePrefab, spawnPoints[RandNumGen()].transform);
            obstacleCounter ++;
        }
    }
}

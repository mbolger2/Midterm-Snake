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

        if (ScoreManager.Instance.score <= 40)
        {
            if (obstacleCounter < 1)
            {
                // A temporary holder for the spawnpoint
                Transform tempSpawn = spawnPoints[RandNumGen()].transform;

                // The 
                if (tempSpawn.transform.position != PlayerMovement.Instance.transform.position)
                {
                    // Spawn obstacle prefab at the position randomly selected
                    Instantiate(obstaclePrefab, tempSpawn);
                    obstacleCounter++;
                }
            }
        }
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLengthController : MonoBehaviour
{
    // Size of array
    public int arraySize = ScoreManager.Instance.score;

    // Define an array to hold the player length
    public GameObject[] playerLength;

    // The body of the snake
    public GameObject body;
    void Start()
    {
        // Set the player length
        playerLength = new GameObject[arraySize + 2];

        //Loop to instantiate gameobjects
        for (int i = 0; i < arraySize; i++)
        {
            // Instantiate the body
            GameObject go = Instantiate(body, transform.position, transform.rotation);

            // 
            playerLength[i+1] = go;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddLength()
    { 
        
    }

}

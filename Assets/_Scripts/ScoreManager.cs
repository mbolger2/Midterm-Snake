using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Current Score
    public int score = 0;

    // The text that will display the value of score
    public TextMeshProUGUI scoreDisplay;

    //
    public static ScoreManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        // We reset the score display
        scoreDisplay.text = "Score: " + score.ToString();

        // We set the instance to this script for referencing
        Instance = this;
    }

    // This func. tells the script to increase score
    public void AddScore(int value)
    {
        // Add the value to the score
        score += value;

        // Display the new score
        scoreDisplay.text = "Score: " + score.ToString();
    }
}

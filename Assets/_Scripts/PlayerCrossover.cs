using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCrossover : MonoBehaviour
{
    [Header("Scenes")]
    public string lossScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Body")
        {
            SceneManager.LoadScene(lossScene);
        }
    }
}
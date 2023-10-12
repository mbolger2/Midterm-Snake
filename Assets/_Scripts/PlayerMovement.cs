using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 dir = Vector2.up;

    void Start()
    {
        // Invokes the methodname (the function Move)
        // .3 seconds after starting and every .3
        // seconds after
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the player input and sets dir
        // to the correct vector2 (0,0)
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
    }

    // Function to move the player
    void Move()
    {
        // Moves the transform in the direction
        // of dir
        transform.Translate(dir);

        if ( dir.x == 1)
        {
            this.transform.Rotate(90, 0, 0);
        }
        else if ( dir.x == -1)
        {
            this.transform.Rotate(-90, 0, 0);
        }
        else if ( dir.y == 1)
        {
            this.transform.Rotate(0, 0, 0);
        }
        else if ( dir.y == -1)
        {
            this.transform.Rotate(180, 0, 0);
        }
    }
}

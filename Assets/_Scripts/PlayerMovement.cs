using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Vector2 dir = Vector2.up;

    // The speed of the player
    public float speed;

    // The rigidbody that controls the player
    public Rigidbody2D rb;

    void Start()
    {
        // Invokes the methodname (the function Move)
        // .3 seconds after starting and every .3
        // seconds after
        // InvokeRepeating("Move", 0.3f, 0.3f);

        // Find a rigidbody2d on the object and assign
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void RotatePlayer90()
    {
        gameObject.transform.eulerAngles = new Vector3(0, 0,
            gameObject.transform.eulerAngles.z + 90);
        //// x-axis movement
        //float h = Input.GetAxis("Horizontal");

        //// y-axis movement
        //float v = Input.GetAxis("Vertical");

        //if (rb.velocity.x == 0)
        //{
        //    if (h > 0)
        //    {

        //        gameObject.transform.eulerAngles = new Vector3(0, 0,
        //            gameObject.transform.eulerAngles.z + 90);
        //    }
        //    else if (h < 0)
        //    {
        //        gameObject.transform.eulerAngles = new Vector3(0, 0,
        //            gameObject.transform.eulerAngles.z - 90);
        //    }
        //}
        //if (rb.velocity.y == 0)
        //{
        //    if (v > 0)
        //    {

        //        gameObject.transform.eulerAngles = new Vector3(0, 0,
        //            gameObject.transform.eulerAngles.z + 90);
        //    }
        //    else if (v < 0)
        //    {
        //        gameObject.transform.eulerAngles = new Vector3(0, 0,
        //            gameObject.transform.eulerAngles.z - 90);
        //    }
        //}
    }

    void RotatePlayerNeg90()
    {
        gameObject.transform.eulerAngles = new Vector3(0, 0,
            gameObject.transform.eulerAngles.z - 90);
    }
    // Update is called once per frame
    void Update()
    {
        // Move the player constantly
        rb.transform.position = new Vector2(transform.position.x,
            transform.position.y);

        
        if (Input.GetAxisRaw("Horizontal") < 0 && rb.velocity.x <= 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0 && rb.velocity.x >= 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else if (Input.GetAxisRaw("Vertical") > 0 && rb.velocity.y >= 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetAxisRaw("Vertical") < 0 && rb.velocity.y <= 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
        }

        


        //// Gets the player input and sets dir
        //// to the correct vector2 (0,0)
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    dir = Vector2.down;
        //}
        //else if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    dir = Vector2.up;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    dir = Vector2.right;
        //}
        //else if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    dir = Vector2.left;
        //}
    }

    //// Function to move the player
    //void Move()
    //{
    //    // Moves the transform in the direction
    //    // of dir
    //    transform.Translate(dir);

    //    if ( dir.x == 1)
    //    {
    //        this.transform.Rotate(90, 0, 0);
    //    }
    //    else if ( dir.x == -1)
    //    {
    //        this.transform.Rotate(-90, 0, 0);
    //    }
    //    else if ( dir.y == 1)
    //    {
    //        this.transform.Rotate(0, 0, 0);
    //    }
    //    else if ( dir.y == -1)
    //    {
    //        this.transform.Rotate(180, 0, 0);
    //    }
    
}

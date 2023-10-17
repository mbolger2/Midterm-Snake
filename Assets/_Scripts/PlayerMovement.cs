using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // The speed of the player
    public float speed;

    // The rigidbody that controls the player
    public Rigidbody2D rb;

    void Start()
    {
        // Find a rigidbody2d on the object and assign
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        // Move the player constantly
        rb.transform.position = new Vector2(transform.position.x,
            transform.position.y);

        // The input is left and the player is not moving right
        if (Input.GetAxisRaw("Horizontal") < 0 && rb.velocity.x <= 0)
        {
            // Rotate gameobject to face left
            gameObject.transform.eulerAngles = new Vector3(0, 0, 90);

            // Move the player left
            rb.transform.position = new Vector2(transform.position.x - (speed / 10), transform.position.y);
        }
        // The input is right and the player is not moving left
        else if (Input.GetAxisRaw("Horizontal") > 0 && rb.velocity.x >= 0)
        {
            // Rotate gameobject to face right
            gameObject.transform.eulerAngles = new Vector3(0, 0, -90);

            // Move the player right
            rb.transform.position = new Vector2(transform.position.x + (speed / 10), transform.position.y);
        }
        // The input is up and the player is not moving down
        else if (Input.GetAxisRaw("Vertical") > 0 && rb.velocity.y >= 0)
        {
            // Rotate gameobject to face up
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);

            // Move the player up
            rb.transform.position = new Vector2(transform.position.x, transform.position.y + (speed / 10));
        }
        // The input is down and the player is not moving up
        else if (Input.GetAxisRaw("Vertical") < 0 && rb.velocity.y <= 0)
        {
            // Rotate gameobject to face down
            gameObject.transform.eulerAngles = new Vector3(0, 0, 180);

            // Move the player down
            rb.transform.position = new Vector2(transform.position.x, transform.position.y - (speed / 10));
        }
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // The speed of the player
    public float speed = 1.0f;

    // Variable to hold time passed
    public float timePassed;

    // The rigidbody that controls the player
    public Rigidbody2D rb;

    public int direction = 0;
    
    // Assign in move function and make it the second statement after &&
    int lastDirection = 0;

    public static PlayerMovement Instance;

    // The proj prefab
    public Projectile projectilePrefab;

    // 
    public Transform projectilePoint;

    void Start()
    {
        // Find a rigidbody2d on the object and assign
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        Instance = this;

        // Call the move function .5 second after start,
        // and every .5 seconds after
        InvokeRepeating("Move", 0.5f, 0.5f);
    }

    void Move()
    {
        // The player input is up
        if (direction == 0)
        {
            // Rotate gameobject to face up
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);

            // Move the player up
            rb.transform.position = new Vector2(transform.position.x,
            transform.position.y + speed);

            lastDirection = direction;

        }
        // The player input is down
        else if (direction == 1)
        {
            // Rotate gameobject to face down
            gameObject.transform.eulerAngles = new Vector3(0, 0, 180);

            // Move the player down
            rb.transform.position = new Vector2(transform.position.x,
            transform.position.y - speed);

            lastDirection = direction;

        }
        // The player input is left
        else if (direction == 2)
        {
            // Rotate gameobject to face left
            gameObject.transform.eulerAngles = new Vector3(0, 0, 90);

            // Move the player left
            rb.transform.position = new Vector2(transform.position.x - speed,
                transform.position.y);

            lastDirection = direction;
        }
        // The player input is right
        else if (direction == 3)
        {
            // Rotate gameobject to face right
            gameObject.transform.eulerAngles = new Vector3(0, 0, -90);

            // Move the player right
            rb.transform.position = new Vector2(transform.position.x + speed,
                transform.position.y);

            lastDirection = direction;

        }
    }

    void Update()
    {
        timePassed += Time.deltaTime;

        // Movement
        // The input is left and the player is not facing right
        if (Input.GetAxisRaw("Horizontal") < 0 && lastDirection != 3)
        {
            direction = 2;
        }
        // The input is right and the player is not facing left
        else if (Input.GetAxisRaw("Horizontal") > 0 && lastDirection != 2)
        {
            direction = 3;
        }
        // The input is up and the player is not facing down
        else if (Input.GetAxisRaw("Vertical") > 0 && lastDirection != 1)
        {
            direction = 0;
        }
        // The input is down and the player is not facing up
        else if (Input.GetAxisRaw("Vertical") < 0 && lastDirection != 0)
        {
            direction = 1;
        }

        // Shooting
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, projectilePoint.position, projectilePoint.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
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

    [Header("Player Collider")]
    BoxCollider2D playerHeadCollider;

    [Header("Projectile")]
    // The proj prefab
    public Projectile projectilePrefab;

    // The point the projectile spawns at
    public Transform projectilePoint;

    [Header("Segments")]
    // The list containing the segments for the snake
    private List<Transform> segments = new List<Transform>();

    // The collider for the body segments
    CapsuleCollider2D bodyCollider;

    // The prefab for the body segment
    public Transform bodyPrefab;

    [Header("Scenes")]
    public string lossScene;
    public string winScene;


    void Start()
    {
        // Find a rigidbody2d on the object and assign
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        //
        segments.Add(this.transform);

        Instance = this;

        // Call the move function .5 second after start,
        // and every .5 seconds after
        InvokeRepeating("Move", 0.5f, 0.5f);
    }

    void Move()
    {
        // Loop to move the bodysegments in reverse order
        // (Set the last body postion to the one in front)
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
            segments[i].rotation = segments[i - 1].rotation;
        }

        // Move the head last so that the body can follow
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

        if (segments.Count == 80)
        {
            SceneManager.LoadScene(winScene);
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, projectilePoint.position, projectilePoint.rotation);
    }

    // Function to add a body segment onto the snake in game
    void GrowSnake()
    {
        // set the transform to be the transform of the body prefab
        Transform bodySegment = Instantiate(this.bodyPrefab, segments[segments.Count - 1].position,
            segments[segments.Count - 1].rotation);


        // Fix the postion to be behind the last
        bodySegment.position = segments[segments.Count - 1].position;
        
        // Get the collider off the gameobject
        bodyCollider = bodySegment.GetComponent<CapsuleCollider2D>();

        // Add the segment to the list
        segments.Add(bodySegment);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // The player collides with the goal
        if (other.tag == "Goal")
        {
           // Snake grows by 1
            GrowSnake();

        }

        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            SceneManager.LoadScene(lossScene);
        }
    }
}
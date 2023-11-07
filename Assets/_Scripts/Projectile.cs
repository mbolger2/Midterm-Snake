using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Speed of Proj
    public float speed;

    // Lifetime of Proj
    public float lifetime = 5.0f;

    // The counter that keeps track of how long
    // this Proj has been around for
    public float lifetimeCounter;

    // Proj prefab
    public GameObject projPrefab;

    // The gameobject we move
    public GameObject projectile;

    // Rb of the proj
    public Rigidbody2D projRig;

    void Start()
    {
        projRig = this.gameObject.GetComponent<Rigidbody2D>();

        InvokeRepeating("MoveProj", 0f, .25f);
    }

    // Update is called once per frame
    private void Update()
    {
        lifetimeCounter += Time.deltaTime;

        if (lifetimeCounter > 0.25)
        {
            // We use the function to keep update clean
            // MoveProj();

            lifetimeCounter = 0;
        }

        if (lifetime > 5.0)
        {
            Destroy(this);
        }

        //// The deltaTime is added to the counter
        //lifetimeCounter += Time.deltaTime;

        // If the counter has exceexed the lifetime
        //if (lifetimeCounter > lifetime)
        //{
        //    // Destroy the Proj
        //    Destroy(this);
        //}
    }

    // Function moves the Proj
    void MoveProj()
    {
        // The projectile is facing up
        if (projRig.transform.eulerAngles == new Vector3(0, 0, 0))
        {
            projRig.transform.position = new Vector2(transform.position.x,
                transform.position.y + speed);
        }
        // The projectile is facing down
        else if (projRig.transform.eulerAngles == new Vector3(0, 0, 180))
        {
            projRig.transform.position = new Vector2(transform.position.x,
                transform.position.y - speed);
        }
        // The projectile is facing left
        else if(projRig.transform.eulerAngles == new Vector3(0, 0, 90))
        {
            projRig.transform.position = new Vector2(transform.position.x - speed,
                transform.position.y);
        }
        // The projectile is facing right
        else if(projRig.transform.eulerAngles == new Vector3(0, 0, 270))
        {
            projRig.transform.position = new Vector2(transform.position.x + speed,
                transform.position.y);
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // The projectile collides with an obstacle
        if (other.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }       
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // The projectile leaves the border of the playable area
        if (other.CompareTag("Border"))
        {
            Destroy(this.gameObject);
        }

    }
}

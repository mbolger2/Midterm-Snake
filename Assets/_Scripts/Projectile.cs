using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Speed of Proj
    public float speed;

    // Lifetime of Proj
    public float lifetime;

    // The counter that keeps track of how long
    // this Proj has been around for
    private float lifetimeCounter;

    // Rb of the proj
    public Rigidbody2D projRig;

    void Start()
    {
        projRig = this.gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        lifetimeCounter += Time.deltaTime;

        // We use the function to keep update clean
        MoveProj();

        //// The deltaTime is added to the counter
        //lifetimeCounter += Time.deltaTime;

        // If the counter has exceexed the lifetime
        if (lifetimeCounter > lifetime)
        {
            // Destroy the Proj
            Destroy(this);
        }
    }

    // Function moves the Proj
    void MoveProj()
    {

        // projRig.transform.position = new Vector2(transform.position)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(this);
    }
}

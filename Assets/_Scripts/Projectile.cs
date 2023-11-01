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
    public float lifetimeCounter;

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

        if (lifetimeCounter > 0.5)
        {
            // We use the function to keep update clean
            MoveProj();

            lifetimeCounter = 0;
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
        if (projRig.transform.eulerAngles == new Vector3(0, 0, 0))
        {
            //projRig.transform.position = projRig.transform.up; 
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(this);
    }
}

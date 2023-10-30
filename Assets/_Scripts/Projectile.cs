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

    // Update is called once per frame
    void Update()
    {
        // We use the function to keep update clean
        // MoveProjectile();

        // The deltaTime is added to the counter
        lifetimeCounter += Time.deltaTime;

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
        // We define a new position vector to easily modify values
        Vector3 newPos = transform.position;

        // We set the new position to be "speed" units along
        // the forward direction
        newPos += transform.forward * speed * Time.deltaTime;

        // Set the new position of the Proj
        transform.position = newPos;
    }
}

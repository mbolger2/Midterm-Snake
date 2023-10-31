using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // The key the player needs to press to shoot
    public string shootButton;

    // The Proj that we'll be shooting
    public Transform projectile;

    // How many seconds pass between each shot
    public float fireRate;

    // An internal counter used to keep track of time
    // passed between shots
    float fireCooldown = 0.5f;


    // Update is called once per frame
    void Update()
    {
        // Add the delta time to the fire cooldown
        fireCooldown += Time.deltaTime;

        // If the cooldwon has reached rate
        // Add && statements for pause menu
        if (fireCooldown >= fireRate
            && Input.GetButtonDown(shootButton))
        {
            // Shoot
            Shoot();

            // Reset the cooldown
            fireCooldown = 0;
        }
    }

    void Shoot()
    {
        // The Proj is spawned at the position of this transform
        // with the default rotation
        Instantiate(projectile, transform.position, transform.rotation);
    }
}

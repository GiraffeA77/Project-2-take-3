using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFiring : MonoBehaviour
{
    public GameObject laserPrefab; 
    public Transform laserSpawnPoint; 
    public float laserSpeed = 50f; 
    public float laserLifetime = 3f; 
    public AudioSource laserSound; 

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        }
    }

    void FireLaser()
    {
        if (laserPrefab != null && laserSpawnPoint != null)
        {
            
            GameObject laser = Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);

            // Add Velocity 
            Rigidbody rb = laser.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = laserSpawnPoint.forward * laserSpeed;
            }

            
            if (laserSound != null)
            {
                laserSound.Play();
            }

            
            Destroy(laser, laserLifetime);
        }
        else
        {
            Debug.LogWarning("Laser prefab or spawn point not assigned!");
        }
    }
}

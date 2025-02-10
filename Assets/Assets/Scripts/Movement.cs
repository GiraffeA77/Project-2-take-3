using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        Vector3 position = transform.position;

        // Get the active terrain
        Terrain terrain = Terrain.activeTerrain;

        // Set the game object's position
        transform.position = position;

        // Translate by 0.1m on Z axis each frame for as long as the W key is held down
        if (Input.GetKey(KeyCode.W))
            // Increment the game object's translation
            transform.Translate(0, 0, 0.1f);

        // Translate by 0.1m backwards on Z axis each frame for as long as the S key is held down
        if (Input.GetKey(KeyCode.S))
            // Increment the game object's translation
            transform.Translate(0, 0, -0.1f);

        // Rotate by 1 degree on Y axis each frame for as long as the A key is held down
        if (Input.GetKey(KeyCode.A))
            // Rotate the game object to the left
            transform.Rotate(Vector3.up, -1.0f);

        // Rotate by 1 degree on Y axis each frame for as long as the D key is held down
        if (Input.GetKey(KeyCode.D))
            // Rotate the game object to the right
            transform.Rotate(Vector3.up, 1.0f);

        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(0, 0, moveVertical);
    }
}

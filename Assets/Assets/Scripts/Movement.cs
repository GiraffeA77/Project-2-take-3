using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Hint: The global static variable "Terrain.activeTerrain" 
        // may be helpful or have useful methods for user here or in
        // other scripts.
        Terrain terrain = Terrain.activeTerrain;

        Vector3 position = transform.position;
        
        // set the game object's translation (not an increment)
        transform.position = position;

        // translate by 0.1m on Z axis each frame for as long as
        // the W key is held down
        if (Input.GetKey (KeyCode.W))
            // increment the game object's translation
            transform.Translate(0, 0, 0.1f);

        // translate by 0.1m backwards on Z axis each frame for as long as
        // the S key is held down
        if (Input.GetKey (KeyCode.S))
            // increment the game object's translation
            transform.Translate(0, 0, -0.1f);

        // translate by 0.1m to the left on X axis each frame for as long as
        // the A key is held down
        if (Input.GetKey (KeyCode.A))
            // increment the game object's translation
            transform.Translate(-0.1f, 0, 0);

       // translate by 0.1m to the left on X axis each frame for as long as
        // the D key is held down
        if (Input.GetKey (KeyCode.D))
            // increment the game object's translation
            transform.Translate(0.1f, 0, 0);
    }
}

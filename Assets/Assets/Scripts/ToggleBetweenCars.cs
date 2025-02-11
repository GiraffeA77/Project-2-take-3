using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBetweenCars : MonoBehaviour
{
     public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    private int currentCameraIndex;

    void Start()
    {
        // Start with the first camera enabled, and others disabled
        currentCameraIndex = 0;
        camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Switch to the next camera
            currentCameraIndex = (currentCameraIndex + 1) % 3;

            // Enable the current camera and disable the others
            camera1.enabled = (currentCameraIndex == 0);
            camera2.enabled = (currentCameraIndex == 1);
            camera3.enabled = (currentCameraIndex == 2);
        }
    }
}


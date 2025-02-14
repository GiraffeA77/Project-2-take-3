using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    public AudioClip drivingClip; // Reference to the driving audio clip
    public AudioClip idleClip; // Reference to the idle audio clip
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = idleClip; // Start with the idle audio clip
        audioSource.loop = true; // Loop the idle sound
        audioSource.Play();
    }

    void Update()
    {
        // Check if the user is pressing the specific key (e.g., "W" key)
        if (Input.GetKeyDown(KeyCode.W))
        {
            audioSource.clip = drivingClip; // Switch to the driving audio clip
            audioSource.loop = true; // Loop the driving sound
            audioSource.Play();
        }

        // Switch back to the idle audio when the key is released
        if (Input.GetKeyUp(KeyCode.W))
        {
            audioSource.clip = idleClip; // Switch back to the idle audio clip
            audioSource.loop = true; // Loop the idle sound
            audioSource.Play();
        }
    }
}

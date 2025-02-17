using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    public AudioClip drivingClip; // Reference to the driving audio clip
    public AudioClip idleClip; // Reference to the idle audio clip
    public AudioClip transitionClip; // Reference to the transition audio clip
    private AudioSource audioSource;
    public float minPitch = 0.5f;
    public float maxPitch = 1.5f;
    public float minVolume = 0.3f;
    public float maxVolume = 1.0f;
    public float maxSpeed = 20f; // Adjust based on your hovercraft's max speed
    public float speed; // Update this with your hovercraft's current speed
    private bool isDriving = false;
    private bool transitioningToIdle = false;
    private bool hasDriven = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = idleClip; // Start with the idle audio clip
        audioSource.loop = true; // Loop the idle sound
        audioSource.Play();
    }

    void Update()
    {
        // Adjust pitch and volume based on speed
        float pitch = Mathf.Lerp(minPitch, maxPitch, speed / maxSpeed);
        float volume = Mathf.Lerp(minVolume, maxVolume, speed / maxSpeed);
        audioSource.pitch = pitch;
        audioSource.volume = volume;

        // Check if the user is pressing the specific key (e.g., "W" key)
        if (Input.GetKeyDown(KeyCode.W))
        {
            isDriving = true;
            transitioningToIdle = false;
            hasDriven = true;
            if (audioSource.clip != drivingClip)
            {
                audioSource.clip = drivingClip; // Switch to the driving audio clip
                audioSource.loop = true; // Loop the driving sound
                audioSource.Play();
            }
        }

        // Start transition clip and then switch to the idle sound
        if (Input.GetKeyUp(KeyCode.W) && !transitioningToIdle)
        {
            isDriving = false;
            if (hasDriven)
            {
                StartCoroutine(PlayTransitionClip());
            }
            else
            {
                StartCoroutine(SwitchToIdle());
            }
        }
    }

    IEnumerator PlayTransitionClip()
    {
        transitioningToIdle = true;
        audioSource.Stop();
        audioSource.clip = transitionClip;
        audioSource.loop = false;
        audioSource.Play();

        // Wait for the transition clip to finish
        yield return new WaitForSeconds(transitionClip.length);

        StartCoroutine(SwitchToIdle());
    }

    IEnumerator SwitchToIdle()
    {
        audioSource.clip = idleClip;
        audioSource.loop = true;
        audioSource.Play();
        transitioningToIdle = false;
        yield break;
    }
}





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBetweenCars : MonoBehaviour
{
    public GameObject[] hovercrafts; 
    public Camera mainCamera; 
    private int currentIndex = 0;

    void Start()
    {
        if (hovercrafts.Length == 0)
        {
            Debug.LogError("No hovercrafts assigned to the ToggleBetweenCars script!");
            return;
        }

        ActivateHovercraft(currentIndex); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && hovercrafts.Length > 1)
        {
            SwitchToNextHovercraft();
        }
    }

    void SwitchToNextHovercraft()
    {
        
        hovercrafts[currentIndex].SetActive(false);

        
        currentIndex = (currentIndex + 1) % hovercrafts.Length;

        
        ActivateHovercraft(currentIndex);
    }

    void ActivateHovercraft(int index)
    {
        hovercrafts[index].SetActive(true);

        
        Camera hovercraftCamera = hovercrafts[index].GetComponentInChildren<Camera>();
        if (hovercraftCamera != null)
        {
            mainCamera.gameObject.SetActive(false);
            hovercraftCamera.gameObject.SetActive(true);
        }
        else
        {
            mainCamera.gameObject.SetActive(true);
        }
    }
}


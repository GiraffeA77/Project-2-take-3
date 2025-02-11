using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false; // Alternatively, set gravityScale to 0: rb. gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

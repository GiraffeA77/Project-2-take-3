using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : MonoBehaviour
{
    public float movementSpeed = 10f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false; // Alternatively, set gravityScale to 0: rb. gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float strafeInput = Input.GetAxis("Horizontal");

        Vector3 movementVector = transform.forward * forwardInput + transform.right * strafeInput;
        movementVector = Vector3.Normalize(movementVector) * movementSpeed;

        rb.velocity = movementVector;
    }
}

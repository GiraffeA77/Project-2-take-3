using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : MonoBehaviour
{
    public List<GameObject> springs;
    public Rigidbody b2;
    public GameObject prop;
    public GameObject CM;

    // Start is called before the first frame update
    void Start()
    {
        b2.centerOfMass = CM.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        b2.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * 400f, prop.transform.position);
        b2.AddTorque(Time.deltaTime * transform.TransformDirection(Vector3.up) * Input.GetAxis("Horizontal") * 300f);
        foreach (GameObject spring in springs) { 
            RaycastHit hit;
            if (Physics.Raycast(spring.transform.position, transform.TransformDirection(Vector3.down), out hit, 3f))
            {
                b2.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.up) * Mathf.Pow(3f - hit.distance, 2) / 3f * 250f, spring.transform.position);
            }
            Debug.Log(hit.distance);
        }
        b2.AddForce(-Time.deltaTime * transform.TransformVector(Vector3.right) * transform.InverseTransformVector(b2.velocity).x * 5f);
    }
}

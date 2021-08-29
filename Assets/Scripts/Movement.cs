using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float thrustSpeed = 500f;
    [SerializeField] float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UserThrust();
        UserRotate();
    }

    void UserThrust(){
       if(Input.GetKey(KeyCode.Space)){
           rb.AddRelativeForce(Vector3.up * Time.deltaTime * thrustSpeed);
        }
    }

    void UserRotate(){
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }

        else if(Input.GetKey(KeyCode.D)){
           ApplyRotation(-rotationSpeed);
        }
    }

    private void ApplyRotation(float rotationFrame)
    {
        rb.freezeRotation = true; //let player take over control of the physics 
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationFrame);
        rb.freezeRotation = false; // resume back to normal physics after player lets go of key 
    }
}

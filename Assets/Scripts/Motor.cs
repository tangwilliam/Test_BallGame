﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {

    public float moveSpeed = 1.0f;
    public float drag = 1.0f;
    public float terminalRotationSpeed = 35.0f;
    public Joystick joystick;

    public float boostSpeed = 10.0f;
    private float boostCoolDown = 2.0f;


    private Rigidbody rb;

    private Transform camTrans;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        rb.drag = drag;
        rb.maxAngularVelocity = terminalRotationSpeed;

        camTrans = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 dir = Vector3.zero;

        // Controls From Keyboard
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        if( dir.magnitude > 1 )
        {
            dir.Normalize();
        }

        // Controls From JoyStick
        if( joystick.InputDirection != Vector3.zero ){

            dir = joystick.InputDirection;
        }


        Vector3 rotatedDir = camTrans.TransformDirection(dir);
        rotatedDir = new Vector3(rotatedDir.x, 0, rotatedDir.z);
        rotatedDir = rotatedDir.normalized * dir.magnitude;

        rb.AddForce(rotatedDir * moveSpeed);



	}

    public void Boost()
    {
        if( Time.time > boostCoolDown )
        {
            rb.AddForce(rb.velocity.normalized * boostSpeed, ForceMode.VelocityChange);
        }
    }
}

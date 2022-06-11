﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float RotationSpeed;
    Rigidbody rb;
    public float force;
    bool hasJump = true;
    public SoundBehaviour myAM;

    // Start is called before the first frame update
    void Start()
    {
        MovementSpeed = 0.1f;
        RotationSpeed = 2.5f;
        rb = GetComponent <Rigidbody>();
        //force = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hasJump)
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            hasJump = false;
            myAM.Salto();
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, MovementSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -MovementSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-MovementSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(MovementSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -RotationSpeed, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, RotationSpeed, 0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground" && gameObject.transform.position.z > 5)
        {
            hasJump = true;
        }
    }
}

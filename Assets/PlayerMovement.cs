using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float maxSpeed = 1.0f;
    float rotation = 0.0f;
    float camRotation = 1.0f;
    float rotationSpeed = 2.0f;
    float camRotationSpeed = 1.5f;
    Rigidbody myRigidBody;
    GameObject cam;

    Rigidbody rb;
    [SerializeField] float movementspeed = 6f;
    [SerializeField] float jumpforce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        {

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            rb.velocity = new Vector3(horizontalInput * movementspeed, rb.velocity.y, verticalInput * movementspeed);

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpforce, rb.velocity.z);
            }
        }


        bool IsGrounded()
        {
            return Physics.CheckSphere(groundCheck.position, .1f, ground);

        }

    }

}
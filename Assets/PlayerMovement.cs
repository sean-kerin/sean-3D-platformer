using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float maxSpeed = 1.0f;
    float rotation = 0.0f;
    float camRotation = 0.0f;
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
            Vector3 newVelocity = transform.forward * Input.GetAxis("vertoical") * maxSpeed;
            myRigidBody.velocity = new Vector3(newVelocity.x, myRigidBody.velocity.y, newVelocity.z);

            rotation = rotation + Input.GetAxis("Mouse X");
            transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

            camRotation = camRotation - Input.GetAxis("Mouse Y") * camRotationSpeed;

            camRotation = Mathf.Clamp(camRotation, -40.0f, 40.0f);

            cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
         rb.velocity = new Vector3(horizontalInput * movementspeed, rb.velocity.y, verticalInput * movementspeed);
       
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x , jumpforce, rb.velocity.z);
        }
    }
    
    bool IsGrounded ()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
    }

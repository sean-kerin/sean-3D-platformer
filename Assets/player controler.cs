using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroler : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;
    public LayerMask LayerMask;
    public bool grounded;
    public float anima;
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        Grounded();
        Jump();
        Move();
    }
    private void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && this.grounded)
        {
            Debug.Log("jumped???");
            this.rb.AddForce(Vector3.up * 6, ForceMode.Impulse);
        }
    }


    private void Grounded()
    {

        if (Physics.CheckSphere(this.transform.position + Vector3.down, anima, LayerMask))
        {
            this.grounded = true;
        }

        else
        {
            this.grounded = false;
        }
        this.anim.SetBool("jump", !this.grounded);
    }

    private void Move()
    {

        float verticalAxis = Input.GetAxis("Vertical");
        float horixontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horixontalAxis;
        movement.Normalize();

        this.transform.position += movement * 0.01f;

        this.anim.SetFloat("vertical", verticalAxis);
        this.anim.SetFloat("horizontal", horixontalAxis);

    }
}

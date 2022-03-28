//Credit Brackeys
//Link: https://www.youtube.com/watch?v=dwcT-Dch0bA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public CharacterController2D controller;

    public float speed = 40f;

    float horizontalmove = 0f;
    public float dashTime = 3f;

    bool jump = false;
    bool crouch = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        } else if (Input.GetButtonDown("Dash"))
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                rb.velocity = Vector2.right * 200;
                while (dashTime > 0)
                {
                    rb.isKinematic = true;
                }
                rb.isKinematic = false;
                rb.velocity = Vector2.right * 0;
            }
            
        }

    }

    void FixedUpdate() {

        controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);

        jump = false;

    }
}

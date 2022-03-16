//Credit Brackeys
//Link: https://www.youtube.com/watch?v=dwcT-Dch0bA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float speed = 40f;

    float horizontalmove = 0f;

    bool jump = false;
    bool crouch = false;

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
        }

    }

    void FixedUpdate() {

        controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);

        jump = false;

    }
}

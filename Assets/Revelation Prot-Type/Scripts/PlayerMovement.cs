//Credit Brackeys
//Link: https://www.youtube.com/watch?v=dwcT-Dch0bA
//Edited by Samuel Benting

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    PlayerControls controls;

    public CharacterController2D controller;

    public float speed = 40f;
    public float dash = 80f;
    public float time = 1f;
    private float backup;

    float horizontalmove = 0f;
    public float dashTime = 3f;

    bool jump = false;
    bool crouch = false;
    bool accel = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        controls = new PlayerControls();

        controls.Gameplay.Left.performed += ctx => Left();
        controls.Gameplay.Left.canceled += ctx => Off();
        controls.Gameplay.Right.performed += ctx => Right();
        controls.Gameplay.Right.canceled += ctx => Off();
        controls.Gameplay.Dash.performed += ctx => Dash();

        controls.Gameplay.Jump.performed += ctx => Jump();
        controls.Gameplay.Down.started += ctx => CrouchOn();
        controls.Gameplay.Down.canceled += ctx => CrouchOff();
    }

    void Start()
    {
        backup = time;
    }

    void Off()
    {
        horizontalmove = 0;
    }

    void Left()
    {
        horizontalmove = -1 * speed;
    }

    void Right()
    {
        horizontalmove = 1 * speed;
    }

    void Jump()
    {
        jump = true;
    }

    void CrouchOn()
    {
        crouch = true;
    }

    void CrouchOff()
    {
        crouch = false;
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    void Dash()
    {
        if (horizontalmove > 0)
        {
            horizontalmove = 1 * dash;
        } else if (horizontalmove < 0)
        {
            horizontalmove = -1 * dash; 
        }
        accel = true;


    }

    void FixedUpdate()
    {

        controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);
        while (accel)
        {
            time -= Time.deltaTime;
            if (horizontalmove > 0 && time == 0)
            {
                horizontalmove = 1 * speed;
                time = backup;
            }
            else if (horizontalmove < 0 && time == 0)
            {
                horizontalmove = -1 * speed;
                time = backup;
            }
        }
        jump = false;

    }
}
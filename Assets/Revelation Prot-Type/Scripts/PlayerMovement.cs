//Credit Brackeys
//Link: https://www.youtube.com/watch?v=dwcT-Dch0bA
//This is not the original from th video. It has been modified to work with new movement
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    PlayerControls controls;

    public CharacterController2D controller;

    public float speed = 10f;
    public float dash = 10f;
    public float time = 10f;
    private float current;
    private float direction;
    private float move;

    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;
    const float k_GroundedRadius = .2f;

    public UnityEvent OnLandEvent;

    float horizontalmove = 0f;

    bool jump = false;
    bool crouch = false;
    bool run = false;
    bool isground = true;
    bool dashing;

    void Awake()
    {
        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
            
        rb = GetComponent<Rigidbody2D>();

        controls = new PlayerControls();

        controls.Gameplay.Left.performed += ctx => Left();
        controls.Gameplay.Left.canceled += ctx => Off();
        controls.Gameplay.Right.performed += ctx => Right();
        controls.Gameplay.Right.canceled += ctx => Off();
        controls.Gameplay.Run.performed += ctx => RunOn();
        controls.Gameplay.Run.canceled += ctx => RunOff();
        controls.Gameplay.Dash.performed += ctx => Dash();
        controls.Gameplay.Jump.performed += ctx => Jump();
        controls.Gameplay.Down.started += ctx => CrouchOn();
        controls.Gameplay.Down.canceled += ctx => CrouchOff();
    }

    void Update()
    {
        move = horizontalmove;
    }

    void Off()
    {
        horizontalmove = 0;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isground = false;
    }

    void Left()
    {
        horizontalmove = -1 * speed;
        if (run)
        {
            horizontalmove = horizontalmove * 1.5f;
        }
    }

    void Right()
    {
        horizontalmove = 1 * speed;
        if (run)
        {
            horizontalmove = horizontalmove * 1.5f;
        }
    }

    void RunOn()
    {
        horizontalmove = horizontalmove * 2;
        run = true;
    }

    void RunOff()
    {
        run = false;
    }

    void Dash()
    {
        if (!isground && horizontalmove != 0)
        {
            dashing = true;
            current = time;
            horizontalmove = 0;
            direction = move;
        }
        while (dashing)
        {
            rb.velocity = transform.right * direction * dash;

            current -= Time.deltaTime;

            if (current <= 0)
            {
                dashing = false;
                
            }
        }
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

    void FixedUpdate()
    {
        bool wasGrounded = isground;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isground = true;
                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                }
            }
        }

        controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}
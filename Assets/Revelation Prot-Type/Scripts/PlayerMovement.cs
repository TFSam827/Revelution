////Credit Brackeys
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

    public float speed = 0f;
    public float time = 0f;
    private float current;
    private float move;

    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;
    const float k_GroundedRadius = .2f;

    public UnityEvent OnLandEvent;

    float horizontalmove = 0f;

    bool jump = false;
    bool crouch = false;
    bool isground = true;
    bool dashing = true;

    void Awake()
    {
        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
            
        rb = GetComponent<Rigidbody2D>();

        controls = new PlayerControls();

        current = time;

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
        while (dashing)
        {
            current -= Time.deltaTime;
            Debug.Log(current);
        }
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
    }

    void Right()
    {
        horizontalmove = 1 * speed;
    }

    void RunOn()
    {
        move = horizontalmove;
        horizontalmove = horizontalmove * 2f;
    }

    void RunOff()
    {
        horizontalmove = move;
    }

    void Dash()
    {
        move = horizontalmove;
        if (!isground && dashing)
        {
            horizontalmove = move * 2;

            if (current <= 0)
            {
                current = time;
                horizontalmove = move;
                Debug.Log("Done");
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
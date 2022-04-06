using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject maxlength;
    public GameObject minlength;
    public GameObject maxheight;
    public GameObject minheight;

    public GameObject player;

    public CharacterController2D controller;

    public float speed = 40f;

    float horizontalmove = 0f;
    public float dashTime = 3f;

    bool jump = false;
    bool crouch = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x == maxlength.transform.position.x)
        {
                horizontalmove = Input.GetAxisRaw("Left") * speed;
        } else if (player.transform.position.x == minlength.transform.position.x)
        {
                horizontalmove = Input.GetAxisRaw("Right") * speed;
        } else if (player.transform.position.y == maxheight.transform.position.y)
        {
            if(Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        } else if (player.transform.position.y == minheight.transform.position.y)
        {
            rb.isKinematic = false;
        }

        rb.isKinematic = true;
    }

    void FixedUpdate()
    {

        controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);

        jump = false;

    }
}

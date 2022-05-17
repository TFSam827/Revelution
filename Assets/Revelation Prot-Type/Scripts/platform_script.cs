using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_script : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerControls controls;

    bool move = false;
    bool top = false;
    bool bottom = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        controls = new PlayerControls();
        controls.Gameplay.Up.performed += ctx => Down();
        controls.Gameplay.Down.performed += ctx => Up();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = true;
        } else if (collision.gameObject.tag == "top")
        {
            top = true;
        } else if (collision.gameObject.tag == "bottom")
        {
            bottom = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = false;
        } else if (collision.gameObject.tag == "top")
        {
            top = false;
        } else if (collision.gameObject.tag == "bottom")
        {
            bottom = false;
        }
    }

    void Off()
    {
        rb.velocity = Vector2.zero;
    }

    void Down()
    {
        if (move && !bottom)
        {
            rb.velocity = Vector2.down;
        }
    }

    void Up()
    {
        if (move && !top)
        {
            rb.velocity = Vector2.up;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_script : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerControls controls;

    public float speed = 0f;

    bool move = false;
    bool top = false;
    bool bottom = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        controls = new PlayerControls();
        controls.Gameplay.Up.performed += ctx => Up();
        controls.Gameplay.Down.performed += ctx => Down();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = true;
            Debug.Log("Move");
        } else if (collision.gameObject.tag == "top")
        {
            top = true;
            Debug.Log("top");
        } else if (collision.gameObject.tag == "bottom")
        {
            bottom = true;
            Debug.Log("bottom");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = false;
            Debug.Log("Player");
        } else if (collision.gameObject.tag == "top")
        {
            top = false;
            Debug.Log("Top");
        } else if (collision.gameObject.tag == "bottom")
        {
            bottom = false;
            Debug.Log("Bottom");
        }
    }

    void Off()
    {
        rb.isKinematic = true;
        Debug.Log("off");
    }

    void Up()
    {
        if (move && !bottom)
        {
            rb.isKinematic = false;
            rb.velocity = Vector2.up * speed;
            Debug.Log("Up");
        }
    }

    void Down()
    {
        if (move && !top)
        {
            rb.isKinematic = false;
            Debug.Log("Down");
        }
    }
}

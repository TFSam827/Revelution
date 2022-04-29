using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_script : MonoBehaviour
{
    PlayerControls controls;

    bool move = false;
    bool top = false;
    bool bottom = false;

    void Awake()
    {
        controls = new PlayerControls();
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

    void Down()
    {
        while (move && !top)
        {
            
        }
    }

    void Up()
    {
        while (move && !bottom)
        {

        }
    }
}

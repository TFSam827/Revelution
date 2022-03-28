using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final_goal : MonoBehaviour
{
    public GameObject win;

    // Start is called before the first frame update
    void Start()
    {
        win.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            win.gameObject.SetActive(true);
            Application.Quit();
        }
    }
}

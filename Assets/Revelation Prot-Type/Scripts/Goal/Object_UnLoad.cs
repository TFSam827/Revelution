using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_UnLoad : MonoBehaviour
{
    public GameObject game;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            game.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Load : MonoBehaviour
{ 
    public GameObject game;

    void Awake()
    {
        game.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            game.SetActive(true);
        }
    }
}

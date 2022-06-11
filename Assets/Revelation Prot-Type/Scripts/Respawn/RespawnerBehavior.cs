using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnerBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player.activeSelf == false)
        {
            player.transform.position = transform.position;
            rb.velocity = Vector3.zero;
            player.SetActive(true);
        }
    }
}

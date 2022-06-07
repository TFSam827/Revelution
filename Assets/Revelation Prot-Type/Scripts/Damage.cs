using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Transform spawner;
    float health = 4f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
        if (health == 0)
        {
            transform.position = spawner.position;
        }
    }

    float Health()
    {
        return health;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject Respawn;

    void OnCollisionEnter2D(Collision2D collision)
    {
            Respawn.transform.position = transform.position;
    }
}

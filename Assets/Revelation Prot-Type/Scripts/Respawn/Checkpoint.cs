using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject Respawn;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 Object = transform.position;
        Object.z = Respawn.transform.position.z;
        Respawn.transform.position = Object;
    }
}

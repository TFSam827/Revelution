using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject spawner;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
        {
            transform.position = spawner.transform.position;
        }
    }
}

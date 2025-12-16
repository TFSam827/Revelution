using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnerBehavior : MonoBehaviour
{

    public GameObject player;

    void Update()
    {
        if (player.activeSelf == false)
        {
            player.transform.position = transform.position;
            player.SetActive(true);
        }
    }
}

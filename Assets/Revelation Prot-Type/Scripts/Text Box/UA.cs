using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UA: MonoBehaviour
{
    public float timer = 0f;
    public GameObject Text;

    void Awake()
    {
        Text.SetActive(false);
    }

    public void Unavalible()
    {
        Text.SetActive(true);

        while(timer != 0)
        {
            timer -= Time.deltaTime;
        }

        Text.SetActive(false);
        timer = 4f;
    }
}

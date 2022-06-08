using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Damage dealt;
    public Animator animate;
    float health;

    // Update is called once per frame
    void Update()
    {
        health = dealt.Health();
        animate.SetFloat("Damage", health);
    }
}

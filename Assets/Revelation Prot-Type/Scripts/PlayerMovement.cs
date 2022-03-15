//Credit Brackeys
//Link: https://www.youtube.com/watch?v=dwcT-Dch0bA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float speed = 40f;

    float horizontalmove = 0f;

    // Update is called once per frame
    void Update()
    {

        horizontalmove = Input.GetAxisRaw("Horizontal") * speed;

    }

    void FixedUpdate() {

        controller.Move(horizontalmove * Time.fixedDeltaTime, false, false);

    }
}

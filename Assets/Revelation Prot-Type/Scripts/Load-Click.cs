using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class click : MonoBehaviour
{
    PlayerControls controls;
    public Scene scene;

    CharacterController2D controller;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Start.performed += ctx => Start();
    }

    void Start()
    {
        SceneManager.LoadScene("Level-Select");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class enter : MonoBehaviour
{
    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Enter.performed += ctx => Enter();
    }

    void Enter()
    {
        SceneManager.LoadScene("Level-Select");
    }
}

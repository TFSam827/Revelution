using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClip : MonoBehaviour
{
    AudioSource fxSound; 
    public AudioClip backMusic;

    void Start()
    {
        fxSound = GetComponent<AudioSource>();
        fxSound.Play();
    }
}

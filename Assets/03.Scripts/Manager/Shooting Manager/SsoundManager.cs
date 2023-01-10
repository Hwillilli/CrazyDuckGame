using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SsoundManager : MonoBehaviour
{
    public AudioClip[] sound_effect;
    AudioSource soundSource;

    void Awake()
    {
        soundSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        
    }
}

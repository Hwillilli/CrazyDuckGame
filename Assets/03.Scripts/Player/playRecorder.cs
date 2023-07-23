using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playRecorder : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] sound_effect;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            audioSource.clip = sound_effect[0];
            audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            audioSource.clip = sound_effect[0];
            audioSource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            audioSource.clip = sound_effect[1];
            audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            audioSource.clip = sound_effect[1];
            audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            audioSource.clip = sound_effect[2];
            audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            audioSource.clip = sound_effect[2];
            audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            audioSource.clip = sound_effect[3];
            audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            audioSource.clip = sound_effect[3];
            audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            audioSource.clip = sound_effect[4];
            audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            audioSource.clip = sound_effect[4];
            audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            audioSource.clip = sound_effect[5];
            audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            audioSource.clip = sound_effect[5];
            audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            audioSource.clip = sound_effect[6];
            audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            audioSource.clip = sound_effect[6];
            audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            audioSource.clip = sound_effect[7];
            audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            audioSource.clip = sound_effect[7];
            audioSource.Stop();
        }
    }
}

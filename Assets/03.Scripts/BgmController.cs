using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class BgmController : MonoBehaviour
{
    Animator anim;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    [YarnCommand("Stopbgm")]
    public void Stop() //¼­¼­È÷ 0
    {
        //anim.SetBool("play", false);
        audioSource.Stop();
    }

    [YarnCommand("Playbgm")]
    public void Play()
    {
        //anim.SetBool("play", true);
        audioSource.Play();
    }
}

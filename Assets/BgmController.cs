using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class BgmController : MonoBehaviour
{
    Animator anim;


    // Start is called before the first frame update
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    [YarnCommand("Stopbgm")]
    public void Stop()
    {
        anim.SetBool("play", false);
    }

    [YarnCommand("Playbgm")]
    public void Play()
    {
        anim.SetBool("play", true);
    }
}

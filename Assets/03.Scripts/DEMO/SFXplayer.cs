using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class SFXplayer : MonoBehaviour
{
    //랜덤사운드(거위울음소리)재생
    private AudioSource soundSource;

    [SerializeField] private AudioClip[] sound_effect;


    void Awake()
    {
        soundSource = GetComponent<AudioSource>();
    }

    public void PlaySFX()
    {
        int _temp = Random.Range(0, 4);

        soundSource.clip = sound_effect[_temp];
        soundSource.Play();
    }

    [YarnCommand("GetItem")] //아이템 획득 효과음
    public void ItemSFX()
    {
        soundSource.clip = sound_effect[0];
        soundSource.Play();
    }
}

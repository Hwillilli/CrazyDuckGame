using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class SFXplayer : MonoBehaviour
{
    //��������(���������Ҹ�)���
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

    [YarnCommand("GetItem")] //������ ȹ�� ȿ����
    public void ItemSFX()
    {
        soundSource.clip = sound_effect[0];
        soundSource.Play();
    }
}

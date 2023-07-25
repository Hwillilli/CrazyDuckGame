using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 1f;
    Vector2 target = new Vector2(0, 0);

    private RectTransform rectTrans;

    Animator anim;
    Rigidbody2D rigid;
    public AudioClip[] sound_effect;
    private AudioSource soundSource;

    void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        soundSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        rectTrans.anchoredPosition = Vector2.MoveTowards
            (rectTrans.anchoredPosition, target, noteSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MissZone")
            anim.SetBool("isMissed", true);
            
            Invoke("vanish", 1f);
    }

    void vanish()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

}

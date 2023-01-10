using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string type;
    //public Image ItemUI;
    //public Sprite sprites;
    //public Image D_Note;
    //public GameObject G_Note;

    public AudioClip[] sound_effect;
    private AudioSource soundSource;

    Animator anim;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
  
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.left * 3;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        soundSource = GetComponent<AudioSource>();

    }
    void OnHit()
    {
        anim.SetTrigger("N_dmg");
        soundSource.clip = sound_effect[0];
        soundSource.Play();
    }
    void vanish()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //ItemUI.sprite = Sprite.Find("Note_collected");
        if (collision.gameObject.tag == "BorderBullet")
            Destroy(gameObject);

        else if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit();

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            //D_Note.SetActive(false);
            //G_Note.SetActive(true);

            anim.SetBool("getItem", true);
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            soundSource.clip = sound_effect[1];
            soundSource.Play();
            //ItemUI.sprite = sprites;
        }
    }
}

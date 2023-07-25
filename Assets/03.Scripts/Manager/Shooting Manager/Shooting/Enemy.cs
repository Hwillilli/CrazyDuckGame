using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;

    Rigidbody2D rigid;
    Animator anim;

    private AudioSource audioSource;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.left * speed;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnHit(int dmg)
    {
        health -= dmg;
        anim.SetTrigger("N_dmg");
        audioSource.Play();

        if (health <= 0)
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            anim.SetBool("N_Destroy", true);
        }
    }

    void vanish()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("N_Destroy", true);
        }
    }
}

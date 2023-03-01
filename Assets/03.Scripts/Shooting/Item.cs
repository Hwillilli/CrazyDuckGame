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

    private string myTarget;

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

            anim.SetBool("Get_Note", true);
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            soundSource.clip = sound_effect[1];
            soundSource.Play();
            //ItemUI.sprite = sprites;

            //음표 상단 UI 변경(채우기) 20230219
            myTarget = this.gameObject.name;

            //Debug.Log("myTarget(부딪힌 음표 이름) : " + myTarget);

            switch (myTarget)//부딪힌 음표
            {
                //quest1
                case "1.Item_R(Clone)"://1.Item_R(Clone) // Red , 7
                    TopNotePrefab.Instance.NoteActiveR();
                    break;
                case "2.Item_O(Clone)":
                    TopNotePrefab.Instance.NoteActiveO();
                    break;
                case "3.Item_Y(Clone)": //노란 음표 프리팹 추가
                    TopNotePrefab.Instance.NoteActiveY();
                    break;
                case "4.Item_G(Clone)":
                    TopNotePrefab.Instance.NoteActiveG();
                    break;
                case "5.Item_S(Clone)":
                    TopNotePrefab.Instance.NoteActiveS();
                    break;
                case "6.Item_B(Clone)":
                    TopNotePrefab.Instance.NoteActiveB();
                    break;
                case "7.Item_P(Clone)":
                    TopNotePrefab.Instance.NoteActiveP();
                    break;

                //quest2
                case "1.Item_R`(Clone)":
                    TopNotePrefab.Instance.NoteActiveR();
                    break;
                case "2.Item_Y`(Clone)":
                    TopNotePrefab.Instance.NoteActiveY();
                    break;
                case "3.Item_G`(Clone)":
                    TopNotePrefab.Instance.NoteActiveG();
                    break;
                case "4.Item_B`(Clone)":
                    TopNotePrefab.Instance.NoteActiveB();
                    break;
                case "5.Item_P`(Clone)":
                    TopNotePrefab.Instance.NoteActiveP();
                    break;
                case "6.Item_Pink`(Clone)":
                    TopNotePrefab.Instance.NoteActivePi();
                    break;

                //quest3
                case "1.Item_O``(Clone)":
                    TopNotePrefab.Instance.NoteActiveO();
                    break;
                case "2.Item_Y``(Clone)":
                    TopNotePrefab.Instance.NoteActiveY();
                    break;
                case "3.Item_G``(Clone)":
                    TopNotePrefab.Instance.NoteActiveG();
                    break;
                case "4.Item_S``(Clone)":
                    TopNotePrefab.Instance.NoteActiveS();
                    break;
                case "5.Item_Pink``(Clone)":
                    TopNotePrefab.Instance.NoteActivePi();
                    break;

                default:
                    break;
            }
        }
    }
}

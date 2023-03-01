using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovefly : MonoBehaviour
{  
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;
    public bool isDamaged;

    public int item = 0;
    int bulletN = 0;
    public int life;
    public float speed;
    public float maxShotDelay;
    public float curShotDelay;

    public GameObject[] bulletobjs;
    public SgameManager manager;
    private AudioSource audioSource;

    public GameObject menuSet;
    public GameObject pauseSet;
    public GameObject settingSet;
    public GameObject controlSet;

    bool IsPause;

    Animator anim;
    Rigidbody2D rigid;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();
        Fire();
        Reload();
        OpenMenu();
    }

    // Open Menu Set
    void OpenMenu()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if ((IsPause == true) && (menuSet.activeSelf))
            {
                menuSet.SetActive(false);
                Time.timeScale = 1;
                IsPause = false;
                controlSet.SetActive(false);
                settingSet.SetActive(false);
                pauseSet.SetActive(true);
                return;
            }

            else
            {
                menuSet.SetActive(true);
                Time.timeScale = 0;
                IsPause = true;
                return;
            }
        }
    }

    public void Reset()
    {
        Time.timeScale = 1;
        IsPause = false;
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;

        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if ((isDamaged == true) || (life == 0) || (item == manager.kind))
        {
            transform.position = curPos;
        }
        else
        {
            transform.position = curPos + nextPos;
        }
    }

    void Fire()
    {
        if ((isDamaged == true) || (curShotDelay < maxShotDelay) || (life == 0) || (item == manager.kind))
            return;

        //for (int bulletObj = 0; bulletObj < bulletobjs.Length; bulletObj++)
        {
            GameObject bullet = Instantiate(bulletobjs[bulletN], transform.position, transform.rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.right * 8, ForceMode2D.Impulse);

            bulletN++;
            if (bulletN == 2)
            {
                bulletN = 0;
            }
        }
        curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            if (isDamaged == false)
            {
                OnDamaged();
            }

            if (life == 0)
            {
                anim.SetBool("gameOver", true);
                manager.GameOver();
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }
        else if(collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            switch (item.type)
            {
                case "Coin":

                    break;

                case "Item":
                    GetItem();

                    break;
            }
        }
    }
     private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }
    }

    void OnDamaged()
    {
        isDamaged = true;
        life--;
        audioSource.Play();
        manager.UpdateLifeIcon(life);
        // Animation
        anim.SetTrigger("doDamaged");
        
        if (life != 0)
        {
            Invoke("OffDamaged", 0.5f);
        }
    }

    void OffDamaged()
    {
        isDamaged = false;
        Fire();
    }

    void GetItem()
    {
        item++;

        if (item == manager.kind)
        {
            manager.GameClear();
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}

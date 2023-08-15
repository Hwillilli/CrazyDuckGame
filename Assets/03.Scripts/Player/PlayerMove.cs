using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerMove : MonoBehaviour
{
    //static public PlayerMove instance;
    private DialogueRunner dialogueRunner = null;
    public float maxSpeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    //player UI
    public GameObject Recorder;
    public GameObject inven;
    public GameObject menuSet;
    public GameObject pauseSet;
    public GameObject settingSet;
    public GameObject controlSet;
    public GameObject CurrScene = null;
    public GameObject NextScene = null;

    public bool notMove = false;
    public bool noPlay = false;
    public bool isRecOpen = false;
    public bool activeInven = false;

    bool IsPause;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    void Update()
    {
        OpenMenu();

        // Open Recorder 
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (noPlay) //리코더열지마
            {
                return;
            }

            //input R 대화 진행
            if (!isRecOpen)
            {
                anim.SetBool("isRecOpen", true);
                isRecOpen = true;
                if((NextScene != null) && (CurrScene != null))
                {
                    NextScene.SetActive(true);
                    CurrScene.SetActive(false);
                }
                    
            }
            else
            {
                anim.SetBool("isRecOpen", false);
                isRecOpen = false;
            }
        }

        if (isRecOpen)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                anim.SetBool("1", true);
            }
            if (!Input.GetKey(KeyCode.Alpha1))
            {
                anim.SetBool("1", false);
            }

            if (Input.GetKey(KeyCode.Alpha2))
            {
                anim.SetBool("2", true);
            }
            if (!Input.GetKey(KeyCode.Alpha2))
            {
                anim.SetBool("2", false);
            }

            if (Input.GetKey(KeyCode.Alpha3))
            {
                anim.SetBool("3", true);
            }
            if (!Input.GetKey(KeyCode.Alpha3))
            {
                anim.SetBool("3", false);
            }

            if (Input.GetKey(KeyCode.Alpha4))
            {
                anim.SetBool("4", true);
            }
            if (!Input.GetKey(KeyCode.Alpha4))
            {
                anim.SetBool("4", false);
            }

            if (Input.GetKey(KeyCode.Alpha5))
            {
                anim.SetBool("5", true);
            }
            if (!Input.GetKey(KeyCode.Alpha5))
            {
                anim.SetBool("5", false);
            }

            if (Input.GetKey(KeyCode.Alpha6))
            {
                anim.SetBool("6", true);
            }
            if (!Input.GetKey(KeyCode.Alpha6))
            {
                anim.SetBool("6", false);
            }

            if (Input.GetKey(KeyCode.Alpha7))
            {
                anim.SetBool("7", true);
            }
            if (!Input.GetKey(KeyCode.Alpha7))
            {
                anim.SetBool("7", false);
            }

            if (Input.GetKey(KeyCode.Alpha8))
            {
                anim.SetBool("8", true);
            }
            if (!Input.GetKey(KeyCode.Alpha8))
            {
                anim.SetBool("8", false);
            }
        }
        

        // Remove all player control when we're in dialogue
        if (dialogueRunner != null && dialogueRunner.IsDialogueRunning == true)
            return;

        //Direction Sprite
        if (Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        //Animation
        float s = Mathf.Abs(rigid.velocity.x);
        anim.SetFloat("isWalking 0", s);

        if (!notMove)
        {
            //Stop Speed
            if (Input.GetButtonUp("Horizontal"))
                rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.3f, 0);

            //Animation
            if (Mathf.Abs(rigid.velocity.x) > 0.3)
                anim.SetBool("isWalking", true);
            else
                anim.SetBool("isWalking", false);
        }
        else
            anim.SetBool("isWalking", false);
            //return;
    }

    public void RecClear() //리코더 열어
    {
        noPlay = false;
    }

    public void noMouse() //마우스 없음
    {
        Cursor.visible = false;
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

    [YarnCommand("MoveClear")] //play Timeline
    public void MoveClear()
    {
        anim.SetBool("isWalking", false);
        notMove = true;
    }
    [YarnCommand("MoveAgain")] //play Timeline
    public void MoveAgain()
    {
        notMove = false;
        noPlay = false;
    }
    public void Pause()
    {
        Time.timeScale = 1;
        IsPause = false;
        return;
    }

    //이동
    void FixedUpdate()
    {
        if (dialogueRunner != null && dialogueRunner.IsDialogueRunning == true)
            return;

        if (!notMove)
        {
            //Move Speed
            float h = Input.GetAxisRaw("Horizontal");
            rigid.AddForce(Vector2.right * h * 10, ForceMode2D.Impulse);

            //Max Speed
            if (rigid.velocity.x > maxSpeed) //Right Max Speed
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            else if (rigid.velocity.x < maxSpeed * (-1)) //Left Max Speed
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }
    void OpenRec()//리코더 열기
    {
        if (Input.GetKeyDown(KeyCode.R) && isRecOpen)
            isRecOpen = false;

        if (Input.GetKeyDown(KeyCode.R) && !isRecOpen)
            isRecOpen = true;
    }
}

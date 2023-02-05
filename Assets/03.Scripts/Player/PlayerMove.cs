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
    public GameObject NextScene = null;
    public GameObject CurrScene = null;

    public bool notMove = false;
    public bool isRecOpen = false;


    void Awake()
    {
        //if (instance == null)
        //{
            //DontDestroyOnLoad(this.gameObject);
            rigid = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            dialogueRunner = FindObjectOfType<DialogueRunner>();
            //instance = this;
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //    //GameObject.SetActive(false);
        //}

    }

    void Update()
    {
        // Open Recorder 
        if (Input.GetKeyDown(KeyCode.R))
        {
            //input R
            if (!isRecOpen)
            {
                anim.SetBool("isRecOpen", true);
                isRecOpen = true;
                NextScene.SetActive(true);
                CurrScene.SetActive(false);
            }
            else
            {
                anim.SetBool("isRecOpen", false);
                isRecOpen = false;
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
    }

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

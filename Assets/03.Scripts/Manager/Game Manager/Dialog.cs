using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;


public class Dialog : MonoBehaviour
{
    //폐기..
    //public bool isDialogOn;
    private PlayerMove thePlayer;

    public PlayableDirector playableDirector;
    public GameObject camOff;
    public GameObject camOn;
    public bool isCamOff = true;
    public GameObject chatBox;
    public GameObject nextChat;
    public Animator talkPanel; //말풍선 on 애니메이션
    public Animator npcMouthAnim;
    public Animator npcAnim2;
    public TextMeshProUGUI textDisplay;

    [TextArea]
    public string[] sentences;
    //public Transform chatTr;
    private int index;

    public float typingSpeed;
    public float delaySpeed;
    public bool isAction = false;
    public bool isMoveAble = false;

    private void Awake()
    {
        chatBox.SetActive(false);
        //talkPanel.SetBool("isShow", true);
        //npcAnim2.SetBool("isfinish", false);
    }

    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
        isAction = true; 
        if (isMoveAble == false)
            NotMove();

        //대화 카메라 설정
        if (camOff != null || camOn != null) 
            camOff.SetActive(false);
            camOn.SetActive(true); 
        //if (isDialogOn == true)
        Invoke("open", delaySpeed);
    }

    /*public void DialogOn()
    {
        isDialogOn = true;
    }*/

    void open()
    {
        chatBox.SetActive(true); //말풍선 준비,애니메이션
        Invoke("type", delaySpeed);
    }
    void type()
    {
        talkPanel.SetBool("isShow", true);
        StartCoroutine(Type());
        Debug.Log("대화 시작");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && isAction == true)
        {
            if(textDisplay.text == sentences[index])
                NextSentence();
        }
    }
    
    IEnumerator Type()
    {
        npcMouthAnim.SetBool("isTalking", true);
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        npcMouthAnim.SetBool("isTalking", false);
    }

    public void NextSentence()
    {
        npcMouthAnim.SetBool("isTalking", true);

        if (index < sentences.Length - 1)
        {
            index++;
                textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            npcMouthAnim.SetBool("isTalking", false);
            StopAllCoroutines();
            close();
            if (playableDirector != null)
            {
                playableDirector.gameObject.SetActive(true);
                playableDirector.Play();

            }
        }
    }

    
    void close()
    {
        Debug.Log("대화 종료");
        isAction = false;
        Move();
        //텍스트 초기화//
        textDisplay.text = null;
        //애니메이션 초기화//
        if (npcAnim2 != null)
            npcAnim2.SetBool("isfinish", true);
        talkPanel.SetBool("isShow", false);
        //chatBox.SetActive(false);
        //카메라 초기화//
        if (isCamOff)
            camOff.SetActive(true);
            camOn.SetActive(false);
        if (nextChat != null)
            nextChat.SetActive(true);//다음 대화 활성화
    }

    public void NotMove()
    {
        thePlayer.notMove = true;
    }
    public void Move()
    {
        thePlayer.notMove = false;
    }
}

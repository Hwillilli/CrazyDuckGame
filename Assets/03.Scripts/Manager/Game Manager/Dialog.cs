using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;


public class Dialog : MonoBehaviour
{
    //���..
    //public bool isDialogOn;
    private PlayerMove thePlayer;

    public PlayableDirector playableDirector;
    public GameObject camOff;
    public GameObject camOn;
    public bool isCamOff = true;
    public GameObject chatBox;
    public GameObject nextChat;
    public Animator talkPanel; //��ǳ�� on �ִϸ��̼�
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

        //��ȭ ī�޶� ����
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
        chatBox.SetActive(true); //��ǳ�� �غ�,�ִϸ��̼�
        Invoke("type", delaySpeed);
    }
    void type()
    {
        talkPanel.SetBool("isShow", true);
        StartCoroutine(Type());
        Debug.Log("��ȭ ����");
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
        Debug.Log("��ȭ ����");
        isAction = false;
        Move();
        //�ؽ�Ʈ �ʱ�ȭ//
        textDisplay.text = null;
        //�ִϸ��̼� �ʱ�ȭ//
        if (npcAnim2 != null)
            npcAnim2.SetBool("isfinish", true);
        talkPanel.SetBool("isShow", false);
        //chatBox.SetActive(false);
        //ī�޶� �ʱ�ȭ//
        if (isCamOff)
            camOff.SetActive(true);
            camOn.SetActive(false);
        if (nextChat != null)
            nextChat.SetActive(true);//���� ��ȭ Ȱ��ȭ
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

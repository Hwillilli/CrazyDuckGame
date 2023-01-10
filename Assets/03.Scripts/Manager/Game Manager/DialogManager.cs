using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogManager : MonoBehaviour
{
    //���� �浹 �� ��ȭ ����, PC �̵� ����
    //public DialogueRunner dialogueRunner;
    private PlayerMove thePlayer;
    //private Dialog theDialog;
    //private MoveObj MoveObject;
    public bool playOnAwake;
    public GameObject Dialgoue = null;
    public GameObject nextDialgoue = null;

    private void Awake()
    {
    //    theDialog = FindObjectOfType<Dialog>();//��ȭ����Ȯ������ ����
        thePlayer = FindObjectOfType<PlayerMove>();
    //    MoveObject = FindObjectOfType<MoveObj>();
    //    dialogueRunner = FindObjectOfType<DialogueRunner>();
        //thePlayer = gameObject.GetComponent<PlayerMove>();//pc ������ ���� ����
 
    }

    //private void Update()
    //{
    //    if (theDialog.isAction == false)
    //        gameObject.GetComponent<MoveObj>().enabled = false;
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (playOnAwake == false)
        {
            //Dialgoue.SetActive(false);
            if (collision.gameObject.tag == "Player")
            {
                Dialgoue.SetActive(true);
                thePlayer.notMove = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                playOnAwake = true;
            }
        }
        if (playOnAwake == true)
        {
            if(collision.gameObject.tag == "Player")
            {
                if (Dialgoue != null)
                    Dialgoue.SetActive(false);
                if (nextDialgoue != null)
                    nextDialgoue.SetActive(true);
                    //gameObject.GetComponent<Dialog>().enabled = true;
                    thePlayer.notMove = true;
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    //thePlayer.notMove = false;
            }
        }
    }
}

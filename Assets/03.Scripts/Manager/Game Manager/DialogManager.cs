using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogManager : MonoBehaviour
{
    //영역 충돌 후 대화 시작, PC 이동 제한
    //public DialogueRunner dialogueRunner;
    private PlayerMove thePlayer;
    //private Dialog theDialog;
    //private MoveObj MoveObject;
    public bool playOnAwake;
    public GameObject Dialgoue = null;
    public GameObject nextDialgoue = null;

    private void Awake()
    {
    //    theDialog = FindObjectOfType<Dialog>();//대화여부확인위한 참조
        thePlayer = FindObjectOfType<PlayerMove>();
    //    MoveObject = FindObjectOfType<MoveObj>();
    //    dialogueRunner = FindObjectOfType<DialogueRunner>();
        //thePlayer = gameObject.GetComponent<PlayerMove>();//pc 움직임 제어 참조
 
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

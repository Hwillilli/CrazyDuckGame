using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class WrapZone : MonoBehaviour
{   //���� ��. pc �浹 �� �� �̵�
    public string transferMapName; //�̵��� �� �̸�
    //public string transferSpot; //�̵� ��ġ
    private PlayerMove thePlayer;
    //private MoveObj theMove = null;//ĳ���� �̵�
    public Animator playerAnim;//ĳ���� �ִϸ��̼�
    public bool isTower; //�ǹ� Ȯ��
    public bool isAnim = false;//�ִϸ��̼� ����
    public GameObject moveUI; //�ǹ� �̵� Ȯ�� �̹���
    public GameObject interfloor; // 

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(!isTower)//�ǹ��ƴϸ� ����� �� �ڵ� �� ��ȯ
            {
                thePlayer.notMove = true;
                //thePlayer.currentMapName = transferSpot;

                //if (isAnim == true)
                //    theMove = FindObjectOfType<MoveObj>();
                //    //gameObject.GetComponent<MoveObj>().enabled = true;
                //    playerAnim.SetBool("isWalking", true);
                //    if (theMove.obj.transform.position == theMove.targetPos)
                //        playerAnim.SetBool("isWalking", false);

                //Invoke("NextGame", 0.5f);
                NextGame();
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isTower)//�ǹ��ƴϸ� ����� �� �ڵ� �� ��ȯ
            {
                moveUI.SetActive(true);
                if (Input.GetKey(KeyCode.W))//�ǹ��̸� ��ư �Է����� ��ȯ
                {
                    NextGame();
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        moveUI.SetActive(false);
    }

    [YarnCommand("Load")] //Load scene
    public void NextGame()
    {
        //�� ������� ��ȯ
        //Scene scene = SceneManager.GetActiveScene();

        //int curScene = scene.buildIndex;
        //int nextScene = curScene + 1;
        //SceneManager.LoadScene(nextScene);

        //�� �̸����� ��ȯ
        SceneManager.LoadScene(transferMapName);
        thePlayer.notMove = false;
    }
}

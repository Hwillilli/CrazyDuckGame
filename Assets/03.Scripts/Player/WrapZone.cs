using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine;
using Yarn.Unity;

public class WrapZone : MonoBehaviour
{   //���� ��. pc �浹 �� �� �̵�
    public string transferMapName; //�̵��� �� �̸�
    private PlayerMove thePlayer;
    //public Animator playerAnim;//ĳ���� �ִϸ��̼�
    public bool isTower; //�ǹ� Ȯ��
    public bool isSend = true; //�̵� Ȯ��
    public GameObject moveUI; //�ǹ� �̵� Ȯ�� �̹���
    public GameObject Dialog;
    public PlayableDirector Timeline;

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
                Timeline.Play();
                Invoke("NextGame", 1f);
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
                    Timeline.Play();
                    if (isSend)
                        Invoke("NextGame", 1f);
                }
                if (Input.GetKey(KeyCode.Space))//��ȭ �ѱ�
                {
                    Dialog.SetActive(true);
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
        //�� �̸����� ��ȯ
        SceneManager.LoadScene(transferMapName);
        thePlayer.notMove = false;
    }
}

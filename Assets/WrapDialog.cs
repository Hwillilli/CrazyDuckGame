using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapDialog : MonoBehaviour
{
    private PlayerMove thePlayer;
    public bool isTower; //�ǹ� Ȯ��
    public bool isAnim = false;//�ִϸ��̼� ����
    public GameObject moveUI; //�ǹ� �̵� Ȯ�� �̹���
    public GameObject yarn; //�ǹ� �̵� Ȯ�� �̹���

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.S))//�ǹ��̸� ��ư���� ��ȯ
            {
                StartDialog();
                moveUI.SetActive(false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        moveUI.SetActive(false);
    }

    public void StartDialog()
    {
        yarn.SetActive(true);
    }
}

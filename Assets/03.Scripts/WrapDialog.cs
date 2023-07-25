using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapDialog : MonoBehaviour
{
    private PlayerMove thePlayer;
    public bool isTower; //건물 확인
    public bool isAnim = false;//애니메이션 적용
    public GameObject moveUI; //건물 이동 확인 이미지
    public GameObject yarn; //건물 이동 확인 이미지

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.S))//건물이면 버튼으로 전환
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

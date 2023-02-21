using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine;
using Yarn.Unity;

public class WrapZone : MonoBehaviour
{   //워프 존. pc 충돌 시 맵 이동
    public string transferMapName; //이동할 맵 이름
    private PlayerMove thePlayer;
    //public Animator playerAnim;//캐릭터 애니메이션
    public bool isTower; //건물 확인
    public bool isSend = true; //이동 확인
    public GameObject moveUI; //건물 이동 확인 이미지
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
            if(!isTower)//건물아니면 닿았을 시 자동 씬 전환
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
            if (isTower)//건물아니면 닿았을 시 자동 씬 전환
            {
                moveUI.SetActive(true);
                if (Input.GetKey(KeyCode.W))//건물이면 버튼 입력으로 전환
                {
                    Timeline.Play();
                    if (isSend)
                        Invoke("NextGame", 1f);
                }
                if (Input.GetKey(KeyCode.Space))//대화 켜기
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
        //씬 이름으로 전환
        SceneManager.LoadScene(transferMapName);
        thePlayer.notMove = false;
    }
}

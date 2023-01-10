using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class WrapZone : MonoBehaviour
{   //워프 존. pc 충돌 시 맵 이동
    public string transferMapName; //이동할 맵 이름
    //public string transferSpot; //이동 위치
    private PlayerMove thePlayer;
    //private MoveObj theMove = null;//캐릭터 이동
    public Animator playerAnim;//캐릭터 애니메이션
    public bool isTower; //건물 확인
    public bool isAnim = false;//애니메이션 적용
    public GameObject moveUI; //건물 이동 확인 이미지
    public GameObject interfloor; // 

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
            if (isTower)//건물아니면 닿았을 시 자동 씬 전환
            {
                moveUI.SetActive(true);
                if (Input.GetKey(KeyCode.W))//건물이면 버튼 입력으로 전환
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
        //씬 순서대로 전환
        //Scene scene = SceneManager.GetActiveScene();

        //int curScene = scene.buildIndex;
        //int nextScene = curScene + 1;
        //SceneManager.LoadScene(nextScene);

        //씬 이름으로 전환
        SceneManager.LoadScene(transferMapName);
        thePlayer.notMove = false;
    }
}

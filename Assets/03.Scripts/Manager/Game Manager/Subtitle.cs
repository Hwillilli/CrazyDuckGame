using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//일러스트 애니메이션 자막 띄우기
public class Subtitle : MonoBehaviour
{
    PlayBGM playBGM;

    public GameObject FormerSubtitle;
    public GameObject NextSubtitle;
    Animator anim;
    public float nextDelay;
    public bool isEnd = false;
    public bool isLoad = false;

    void Start() {
        playBGM = FindObjectOfType<PlayBGM>();
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Next", false);
        //NextSubtitle.SetActive(false);
    }

    private void Update()
    {   //S입력 후 다음 문장
        if (Input.GetKeyDown(KeyCode.S) && isEnd == true)
        {
            anim.SetBool("Next", true);

            if (isLoad == true)
            {
                //FormerSubtitle.gameObject.SetActive(false);
                Scene scene = SceneManager.GetActiveScene();

                int curScene = scene.buildIndex;
                int nextScene = curScene + 1;
                SceneManager.LoadScene(nextScene);
            }

        }
    }

    public void next()
    {
        if (NextSubtitle != null)
        {
            Debug.Log(NextSubtitle);
            switch (NextSubtitle.name) {
                case "... 아니,":
                    playBGM.PlayMusic(2);
                    break;
                case "갑자기 생겨났던":
                    playBGM.PlayMusic(3);
                    playBGM.LoopFalse();
                    break;
                case "치즈마을을 위협하는":
                    playBGM.PlayMusic(2);
                    playBGM.LoopTrue();
                    break;
                case "그리고":
                    playBGM.PlayMusic(4);
                    playBGM.LoopTrue();
                    break;
                //case ""
                default: break;
            }

            NextSubtitle.SetActive(true);
        }
        
    }


    public void IsEnd()
    {
        isEnd = true;
    }
}

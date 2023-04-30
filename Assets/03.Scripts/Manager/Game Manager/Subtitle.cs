using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�Ϸ���Ʈ �ִϸ��̼� �ڸ� ����
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
    {   //S�Է� �� ���� ����
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
                case "... �ƴ�,":
                    playBGM.PlayMusic(2);
                    break;
                case "���ڱ� ���ܳ���":
                    playBGM.PlayMusic(3);
                    playBGM.LoopFalse();
                    break;
                case "ġ����� �����ϴ�":
                    playBGM.PlayMusic(2);
                    playBGM.LoopTrue();
                    break;
                case "�׸���":
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

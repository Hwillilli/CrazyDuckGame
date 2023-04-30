using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//일러스트 애니메이션 자막 띄우기
public class Subtitle : MonoBehaviour
{
    public GameObject FormerSubtitle;
    public GameObject NextSubtitle;
    Animator anim;
    public float nextDelay;
    public bool isEnd = false;
    public bool isLoad = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Next", false);
        //NextSubtitle.SetActive(false);
    }

    private void Update()
    {   //S입력 후 다음 문장
        if (Input.GetKeyDown(KeyCode.Space) && isEnd == true)
        {
            anim.SetBool("Next", true);

            if (isLoad == true)
            {
                Invoke("load", 1f);
                
            }

        }
    }

    public void next()
    {
        if (NextSubtitle != null)
        {
            NextSubtitle.SetActive(true);
        }
        
    }

    public void IsEnd()
    {
        isEnd = true;
    }

    public void load()
    {
        //FormerSubtitle.gameObject.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();

        int curScene = scene.buildIndex;
        int nextScene = curScene + 1;
        SceneManager.LoadScene(nextScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�Ϸ���Ʈ �ִϸ��̼� �ڸ� ����
public class Subtitle : MonoBehaviour
{
    public GameObject FormerSubtitle;
    public GameObject NextSubtitle;
    public GameObject fade;
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
    {   //S�Է� �� ���� ����
        if (isEnd == true)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("Cancel"))
                    return;

                else
                {
                    anim.SetBool("Next", true);
                    if (isLoad == true)
                    {
                        fade.SetActive(true);
                        Invoke("Load", 1f);
                    }
                }
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
    public void Load()
    {
        //FormerSubtitle.gameObject.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();

        int curScene = scene.buildIndex;
        int nextScene = curScene + 1;
        SceneManager.LoadScene(nextScene);
    }
}

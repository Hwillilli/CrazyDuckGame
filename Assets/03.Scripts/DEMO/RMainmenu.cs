using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RMainmenu : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;
    public void PlayGame()
    {
        StartCoroutine(LoadScene());
        Debug.Log("게임시작");
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);

    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("게임종료");
    }
}


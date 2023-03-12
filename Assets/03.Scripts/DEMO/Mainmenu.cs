using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;
    public void PlayGame()
    {
        StartCoroutine(LoadScene());
        Debug.Log("방송시작");
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
        Debug.Log("방송종료");
    }
}


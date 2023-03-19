using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenMouse : MonoBehaviour
{
    public string sceneName;

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(8.0f);
        SceneManager.LoadScene(sceneName);
        Debug.Log("오류 복구중");
        
    }

    void Update()
    {
        Cursor.visible = false;
        StartCoroutine(LoadScene());
        

    }
}

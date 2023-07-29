using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenMouse : MonoBehaviour
{
    public string sceneName;
    public bool load = true;

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(13.0f);
        SceneManager.LoadScene(sceneName);
        Debug.Log("오류 복구중");
        
    }

    void Update()
    {
        Cursor.visible = false;
        if (load == true)
        {
            StartCoroutine(LoadScene());
        }
    }
}

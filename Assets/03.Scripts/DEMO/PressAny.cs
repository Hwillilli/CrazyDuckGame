using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAny : MonoBehaviour
{
    public GameObject Pressany;
    public GameObject mainbuttons;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            mainbuttons.SetActive(true);
            Pressany.SetActive(false);
            Debug.Log("플레이어가 아무 키를 눌렀습니다.");
            Cursor.visible = true;
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDialog : MonoBehaviour
{
    public GameObject[] Dialog;
    public GameObject last;

    void Update()
    {
        bool allObjectsActive = true;

        // 모든 8개의 오브젝트가 활성화되어 있는지 확인합니다.
        foreach (GameObject obj in Dialog)
        {
            if (!obj.activeSelf)
            {
                allObjectsActive = false;
                break; // 하나라도 비활성화된 오브젝트가 있으면 루프를 빠져나옵니다.
            }
        }

        // 모든 오브젝트가 활성화되었다면 "a" 오브젝트를 활성화합니다.
        if (allObjectsActive)
        {
            last.SetActive(true);
        }
        else
        {
            last.SetActive(false);
        }
    }


}

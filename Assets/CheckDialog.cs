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

        // ��� 8���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ��� Ȯ���մϴ�.
        foreach (GameObject obj in Dialog)
        {
            if (!obj.activeSelf)
            {
                allObjectsActive = false;
                break; // �ϳ��� ��Ȱ��ȭ�� ������Ʈ�� ������ ������ �������ɴϴ�.
            }
        }

        // ��� ������Ʈ�� Ȱ��ȭ�Ǿ��ٸ� "a" ������Ʈ�� Ȱ��ȭ�մϴ�.
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineControll : MonoBehaviour
{   //�� �Ϸ��� ���� �ڵ����� �𸣰ڳ׿�
    public CinemachineVirtualCamera cinevirtual;

    public GameObject tPlayer;
    public Transform tFollowTarget;
    private CinemachineVirtualCamera vcam;

    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();

        if (tPlayer == null)
        {
            tPlayer = GameObject.FindWithTag("Player");
        }
        tFollowTarget = tPlayer.transform;
        //vcam.LookAt = tFollowTarget;
        vcam.Follow = tFollowTarget;
    }

    //void SetFollow()
    //{
    //    // �ó׸ӽ� ��ü�� �����Ϸ��� �̷��� �ص� �ȴ�.
    //    cinevirtual.m_Lens.FieldOfView = 60;

    //    // ������ transposer �� follow offset�� �����Ϸ��� �Ʒ��� ���� ������Ʈ�� ��������
    //    // ������� �����;� �Ѵ�.
    //    cinevirtual.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y = 10;
    //}

}

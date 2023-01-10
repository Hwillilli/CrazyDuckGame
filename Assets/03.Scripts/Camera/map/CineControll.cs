using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineControll : MonoBehaviour
{   //뭘 하려고 만든 코드인지 모르겠네요
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
    //    // 시네머신 자체에 접근하려면 이렇게 해도 된다.
    //    cinevirtual.m_Lens.FieldOfView = 60;

    //    // 하지만 transposer 의 follow offset에 접근하려면 아래와 같이 컴포넌트를 가져오는
    //    // 방식으로 가져와야 한다.
    //    cinevirtual.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y = 10;
    //}

}

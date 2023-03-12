using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WallconManager : MonoBehaviour
{
    public GameObject Sintranet;    //신트라넷 팝업창
    public GameObject Closed;       //슈의 라면가게 팝업창
    public GameObject CrazyDuck;    //지컨아세요 오류창



    public void sintranet()
    {
        Sintranet.SetActive(true);
        Debug.Log("아이디 카드를 넣어주십시오.");
    }

    public void EscSintranet()
    {
        Sintranet.SetActive(false);
        Debug.Log("신트라넷 종료");
    }
    public void closed()
    {
        Closed.SetActive(true);
        Debug.Log("영업 종료 안내");
    }
    public void EscClosed()
    {
        Closed.SetActive(false);
        Debug.Log("라면가게를 떠남");
    }
    public void crazyduck()
    {
        CrazyDuck.SetActive(true);
        Debug.Log("지컨 아세요?");
    }
    public void Cafe()
    {
        Application.OpenURL("https://cafe.daum.net/zkern");
    }
}




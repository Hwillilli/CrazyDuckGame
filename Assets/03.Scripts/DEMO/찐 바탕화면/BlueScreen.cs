using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScreen : MonoBehaviour
{
    public GameObject obj;                    //경고창
    public GameObject error;                    //블루스크린
    public Transform parent;



    //private void Get_MouseInput()
    //{

    //}




    private void Update()
    {
        if (gameObject.activeSelf == true)//지컨아세요 오류창 활성화 상태
        {
            //화면 클릭시
            if (Input.GetMouseButtonDown(0))
            {
                error.SetActive(true);


            }


            //error.SetActive(true);          //블루스크린 활성화
        }
    }

}
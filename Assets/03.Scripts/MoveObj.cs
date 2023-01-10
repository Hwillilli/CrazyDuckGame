using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{   //할로우나이트처럼 맵 이동시 화면 전환 후 특정 지점까지 pc 이동, 애니메이션 실행 -> 실패
    //이동할 오브젝트/목표위치
    public GameObject obj;
    public Vector3 targetPos;
    //public SpriteRenderer objRender;
    //SpriteRenderer spriteRenderer;

    void Awake()
    {
        //objRender = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        obj.transform.position =
            Vector3.MoveTowards(obj.transform.position, targetPos, 0.1f);
        /*if (objRender.flipX == true)
            objRender.flipX = false;*/
    }
}

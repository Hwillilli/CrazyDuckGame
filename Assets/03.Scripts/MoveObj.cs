using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{   //�ҷο쳪��Ʈó�� �� �̵��� ȭ�� ��ȯ �� Ư�� �������� pc �̵�, �ִϸ��̼� ���� -> ����
    //�̵��� ������Ʈ/��ǥ��ġ
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

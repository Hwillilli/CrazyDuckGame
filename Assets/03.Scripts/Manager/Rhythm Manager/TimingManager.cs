using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    //���� ��ũ��Ʈ
    //���� ��Ʈ�� ��� list ���������� �ִ��� ��
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform Center = null;//���� ���� �߽� ??���� �𸣰ڴµ�..
    [SerializeField] RectTransform[] timingRect = null;//��������
    Vector2[] timingBoxs = null; //���� ������ �ּ�,�ִ밪

    void Start()
    {
        //Ÿ�̹� �ڽ� ����, center�� ��� �����ؾ��ϳ�..
        timingBoxs = new Vector2[timingRect.Length];
        for(int i=0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,
                              Center.localPosition.x + timingRect[i].rect.width / 2);
        }
    }

    public void CheckTiming()
    {
        for(int i = 0; i <boxNoteList.Count; i++)
        {
            float t_notePoX = boxNoteList[i].transform.localPosition.x;
            float t_notePoY = boxNoteList[i].transform.localPosition.y;

            for(int x = 0; x < timingBoxs.Length; x++)
            {
                if(timingBoxs[x].x <= t_notePoX && t_notePoX <= timingBoxs[x].y)
                {
                    Debug.Log("Hit" + x);
                    return;
                }
            }
            for(int y = 0; y < timingBoxs.Length; y++)
            {
                if(timingBoxs[y].x <= t_notePoX && t_notePoX <= timingBoxs[y].y)
                {
                    Debug.Log("Hit" + y);
                    return;
                }
            }
        }

        Debug.Log("Miss");
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    //판정 스크립트
    //생성 노트를 담는 list 판정범위에 있는지 비교
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform Center = null;//판정 범위 중심 ??뭔지 모르겠는데..
    [SerializeField] RectTransform[] timingRect = null;//판정범위
    Vector2[] timingBoxs = null; //판정 범위의 최소,최대값

    void Start()
    {
        //타이밍 박스 설정, center를 어떻게 설정해야하나..
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

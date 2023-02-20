using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopNotePrefab : MonoBehaviour
{
    public static TopNotePrefab instance = null;
    public GameObject TargetR;
    public GameObject TargetO;
    public GameObject TargetY;
    public GameObject TargetG;
    public GameObject TargetS;
    public GameObject TargetB;
    public GameObject TargetP;

    public GameObject TargetPi;
    //public BoxCollider Target;

    void Awake() {
        instance = this;
    }

    public static TopNotePrefab Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //빨간 음표
    public void NoteActiveR() {
        TargetR.SetActive(true);
    }

    //주황 음표
    public void NoteActiveO()
    {
        TargetO.SetActive(true);
    }

    //노란 음표
    public void NoteActiveY()
    {
        TargetY.SetActive(true);
    }

    //초록 음표
    public void NoteActiveG()
    {
        TargetG.SetActive(true);
    }

    //하늘색 음표
    public void NoteActiveS()
    {
        TargetS.SetActive(true);
    }

    //파란 음표
    public void NoteActiveB()
    {
        TargetB.SetActive(true);
    }

    //보라 음표
    public void NoteActiveP()
    {
        TargetP.SetActive(true);
    }

    //분홍 음표
    public void NoteActivePi()
    {
        TargetPi.SetActive(true);
    }
}

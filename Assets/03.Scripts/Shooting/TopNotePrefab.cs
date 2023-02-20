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

    //���� ��ǥ
    public void NoteActiveR() {
        TargetR.SetActive(true);
    }

    //��Ȳ ��ǥ
    public void NoteActiveO()
    {
        TargetO.SetActive(true);
    }

    //��� ��ǥ
    public void NoteActiveY()
    {
        TargetY.SetActive(true);
    }

    //�ʷ� ��ǥ
    public void NoteActiveG()
    {
        TargetG.SetActive(true);
    }

    //�ϴû� ��ǥ
    public void NoteActiveS()
    {
        TargetS.SetActive(true);
    }

    //�Ķ� ��ǥ
    public void NoteActiveB()
    {
        TargetB.SetActive(true);
    }

    //���� ��ǥ
    public void NoteActiveP()
    {
        TargetP.SetActive(true);
    }

    //��ȫ ��ǥ
    public void NoteActivePi()
    {
        TargetPi.SetActive(true);
    }
}

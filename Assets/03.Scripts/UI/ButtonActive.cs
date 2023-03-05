using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActive : MonoBehaviour
{
    public GameObject Button01;
    public GameObject Button02;
    public GameObject Button03;

    public GameObject PieceImage01;
    public GameObject PieceImage02;
    public GameObject PieceImage03;
    public GameObject noteX;
    int pieceCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActBtn()
    {
        //invenUI.activeInven = false;
       
        Button01.SetActive(true);
        Button02.SetActive(true);
        Button03.SetActive(true);

        //Music_of_Sue = 1;
    }

    public void ClickBtn01()
    {
        PieceImage01.SetActive(false);
        Button01.SetActive(false);
        pieceCnt += 1;
        if (pieceCnt == 3) noteX.SetActive(true);
    }
    public void ClickBtn02()
    {
        PieceImage02.SetActive(false);
        Button02.SetActive(false);
        pieceCnt += 1;
        if (pieceCnt == 3) noteX.SetActive(true);
    }
    public void ClickBtn03()
    {
        PieceImage03.SetActive(false);
        Button03.SetActive(false);
        pieceCnt += 1;
        if (pieceCnt == 3) noteX.SetActive(true);
    }
    /*public void setActNoteX() {
        noteX.SetActive(true);
    }*/
}

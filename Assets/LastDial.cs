using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDial : MonoBehaviour
{
    public GameObject[] dialog;

    bool allActive = true;

    private void Update()
    {
        for (int i = 0; i < dialog.Length; i++)
        {
            if (!dialog *.activeInHierarchy)
            {
                allActive = false;
                break; //this ¡°quits¡± the for loop, you don¡¯t need to check the rest of the items if you already found one that¡¯s not active

                if (allActive)
                {
                    DoSomething();
                }

            }
        }
    }
}

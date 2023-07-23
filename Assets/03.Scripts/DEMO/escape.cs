using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escape : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("플레이 해주셔서 감사합니다.");
    }
}

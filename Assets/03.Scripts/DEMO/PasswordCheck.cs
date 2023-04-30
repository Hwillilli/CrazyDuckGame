using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class PasswordCheck : MonoBehaviour
{
    private string password = "지컨";
    public InputField UserInput;
    public string USERINPUT;

    
    public void CheckPassword ()
    {
        USERINPUT = UserInput.text;
        

        if (USERINPUT == password)
        {
            SceneManager.LoadScene("03.on-air");
        }
        else
        {
            //FindObjectOfType<AudioManager>().Play("access-denied");
            Debug.Log("다시 시도하세요");
        }
    }
}

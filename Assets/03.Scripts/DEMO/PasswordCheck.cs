using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class PasswordCheck : MonoBehaviour
{
    private string password = "지컨";
    private string password2 = "이지경";
    public InputField UserInput;
    public string USERINPUT;
    private AudioSource soundSource;

    void Awake()
    {
        soundSource = GetComponent<AudioSource>();
    }

    public void CheckPassword ()
    {
        USERINPUT = UserInput.text;
        

        if (USERINPUT == password || USERINPUT == password2)
        {
            SceneManager.LoadScene("03.on-air");
        }
        else
        {
            soundSource.Play();
            //FindObjectOfType<AudioManager>().Play("access-denied");
            Debug.Log("다시 시도하세요");
        }
    }
}

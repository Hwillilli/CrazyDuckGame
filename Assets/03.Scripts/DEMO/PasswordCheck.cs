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
    public GameObject input;
    public GameObject textBox;
    private AudioSource soundSource;

    void Awake()
    {
        soundSource = GetComponent<AudioSource>();
    }

    public void CheckPassword ()
    {
        USERINPUT = UserInput.text;
        

        if (USERINPUT == password)
        {
            SceneManager.LoadScene("03.on-air");
        }
        else
        {
            input.SetActive(true);
            textBox.SetActive(false);
            soundSource.Play();
            Debug.Log("다시 시도하세요");
            
            if (Input.anyKeyDown)
            {
                input.SetActive(false);
                textBox.SetActive(true);
            }
        }
    }
}

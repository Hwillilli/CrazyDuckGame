using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;


public class Choice : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject choiceBox;
    public Animator choicePanel;
    public TextMeshProUGUI[] textDisplay;


    public bool isAction = false;

    private void Awake()
    {
        choiceBox.SetActive(false);
    }

    private void Start()
    {
        choiceBox.SetActive(true);
        isAction = true;
        Invoke("open", 0.5f);
    }

}

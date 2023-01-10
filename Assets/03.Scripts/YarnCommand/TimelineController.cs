using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;
using Yarn.Unity;

public class TimelineController : MonoBehaviour
{
    private DialogueRunner dialogueRunner = null;
    public PlayableDirector Timeline;

    void Awake()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    [YarnCommand("play")] //play Timeline
    public void playTimeline()
    {
        //var findTimeline = FindTimeline( timelineName );
        //findTimeline.gameObject.SetActive(true);
        //transform.GetChild[i]gameObject.SetActive(true);
        //var gameObject = GameObject.Find(name);
        //gameObject.SetActive(true);
        Timeline.Play();
    }
    
    [YarnCommand("CamChange")] // change cam
    public void CamChange()
    {
        gameObject.SetActive(true);
    }

    [YarnCommand("pause")] // change cam
    public void pauseTimeline()
    {
        Timeline.Pause();
    }

    [YarnCommand("stop")] // change cam
    public void stopTimeline()
    {
        Timeline.Stop();
    }
}

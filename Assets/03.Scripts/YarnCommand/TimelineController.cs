using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;
using Yarn.Unity;

public class TimelineController : MonoBehaviour
{
    private DialogueRunner dialogueRunner = null;
    public PlayableDirector Timeline;
    public bool isUI;

    void Awake()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        if (isUI)
        {
            Invoke("OffTimeline", 1.2f);
        }
    }

    [YarnCommand("play")] //play Timeline
    public void playTimeline()
    {
        Timeline.Play();
    }
    
    [YarnCommand("CamChange")] 
    public void CamChange()
    {
        gameObject.SetActive(true);
    }

    [YarnCommand("pause")] 
    public void pauseTimeline()
    {
        Timeline.Pause();
    }

    [YarnCommand("stop")]
    public void stopTimeline()
    {
        Timeline.Stop();
    }
    
    public void OffTimeline()
    {
        Destroy(gameObject);
    }
}

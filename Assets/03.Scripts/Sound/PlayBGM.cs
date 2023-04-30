using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    static public PlayBGM instance;

    BGMManager BGM;

    public int playMusicTrack;
    /**
     * 0 : 마을 스토리 느낌 BGM
     * 1 : 숲 소리 BGM
     * 2 : 미니 천둥 효과음
     * 3 : 큰 천둥 효과음
     * 
     * 
     * 
      */


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        BGM = FindObjectOfType<BGMManager>();

        PlayMusic(playMusicTrack);
    }

    public void PlayMusic(int _trackNum)
    {
        Debug.Log("playMusicTrack : " + _trackNum);
        BGM.Play(_trackNum);
    }

    public void FadeOutMusic()
    {
        Debug.Log("FadeOutMusic");
        BGM.FadeOutMusic();
    }
    public void FadeInMusic()
    {
        Debug.Log("FadeInMusic");
        BGM.FadeInMusic();
    }
    public void LoopTrue()
    {
        Debug.Log("LoopTrue");
        BGM.LoopTrue();
    }
    public void LoopFalse()
    {
        Debug.Log("LoopFalse");
        BGM.LoopFalse();
    }
    public void InvokeMusic(int _nextTrackNum) {
        Invoke("PlayMusic", 2f);
        //PlayMusic(_nextTrackNum);
    }

    /* private void OnTriggerEnter2D(Collider2D collision) {
         BGM.Play(playMusicTrack);
     }*/

    // Update is called once per frame
    void Update()
    {

    }
}

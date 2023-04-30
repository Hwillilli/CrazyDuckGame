using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    static public BGMManager instance;

    public AudioClip[] clips; //πË∞Ê¿Ωæ«µÈ

    private AudioSource source;

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    private void Awake() {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play(int _palyMusicTrack) {
        source.clip = clips[_palyMusicTrack];
        source.Play();
    }

    public void Stop() {
        source.Stop();
    }

    public void FadeOutMusic() {
        StopAllCoroutines();
        StartCoroutine(FadeOutMusicCoroutine());
    }

    IEnumerator FadeOutMusicCoroutine() {
        for (float i = 1.0f; i >= 0f; i -= 0.001f) {
            source.volume = i;
            yield return waitTime;
        }
    }

    public void FadeInMusic() {
        StopAllCoroutines();
        StartCoroutine(FadeInMusicCoroutine());
    }

    IEnumerator FadeInMusicCoroutine()
    {
        for (float i = 0f; i <= 1f; i += 0.001f)
        {
            source.volume = i;
            yield return waitTime;
        }
    }

    public void LoopTrue() {
        source.loop = true;
    }
    public void LoopFalse()
    {
        source.loop = false;
    }
}

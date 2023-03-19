using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum FadeState { FadeIn = 0, FadeOut, FadeInOut, FadeLoop }

public class FadeIn : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float           fadeTime;
    [SerializeField]
    private AnimationCurve  fadeCurve;
    private Image           image;
    private FadeState       fadeState;

    private void Awake()
    {
        image = GetComponent<Image>();

        StartCoroutine(Fade(1, 0));
        OnFade(FadeState.FadeIn);
    }

    public void OnFade(FadeState state)
    {
        fadeState = state;

        switch (fadeState)
        {
            case FadeState.FadeIn:
                StartCoroutine(Fade(1, 0));
                break;
            case FadeState.FadeOut:
                StartCoroutine(Fade(0, 1));
                break;
            case FadeState.FadeInOut:
            case FadeState.FadeLoop:
                StartCoroutine(FadeInOut());
                break;
        }
    }

    private IEnumerator FadeInOut()
    {
        while ( true )
        {
            yield return StartCoroutine(Fade(1, 0));    // Fade In

            yield return StartCoroutine(Fade(0, 1));    // Fade Out

            if ( fadeState == FadeState.FadeInOut )
            {
                break;
            }
        }
    }
    private IEnumerator Fade(float start, float end)
    {
        float currentTime    = 0.0f;
        float percent        = 0.0f;

        while ( percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = image.color;
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            image.color = color;

            yield return null;
        }
    }
}



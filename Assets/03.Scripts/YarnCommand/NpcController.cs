using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.Playables;

public class NpcController : MonoBehaviour
{
    Animator anim;
    public Animator animator;
    private DialogueRunner dialogueRunner = null;
    public SpriteRenderer rend;
    //[Header("Optional")]
    //public YarnProgram scriptToLoad;

    void Awake()
    {
        anim = GetComponent<Animator>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        rend = GetComponent<SpriteRenderer>();
        //if (dialogueRunner.IsDialogueRunning == true)
    }
    
    [YarnCommand("flip")]
    public void flip()
    {
        rend.flipX = true;
        Debug.Log($"{name} is Speaking");
    }
    [YarnCommand("reflip")]
    public void reflip()
    {
        rend.flipX = false;
        Debug.Log($"{name} is Speaking");
    }

    [YarnCommand("Speak")]
    public void Speak()
    {
        animator.SetBool("isTalking", true);
        Debug.Log($"{name} is Speaking");
    }
    [YarnCommand("StopSpeak")]
    public void StopSpeak()
    {
        animator.SetBool("isTalking", false);
        Debug.Log($"{name} is stopped Speaking");
    }

    [YarnCommand("Appear")]
    public void Appear()
    {
        animator.SetBool("isAppear", true);
    }
    [YarnCommand("Disappear")]
    public void Disappear()
    {
        animator.SetBool("isAppear", false);
    }
    [YarnCommand("Waking")]
    public void Waking()
    {
        animator.SetBool("isWaking", true);
    }
    [YarnCommand("SWaking")]
    public void SWaking()
    {
        animator.SetBool("isWaking", false);
    }

    [YarnCommand("one_On")]
    public void oneOn()
    {
        animator.SetBool("isOne", true);
    }
    [YarnCommand("one_Off")]
    public void oneOff()
    {
        animator.SetBool("isOne", false);
    }
    [YarnCommand("two_On")]
    public void twoOn()
    {
        animator.SetBool("isTwo", true);
    }
    [YarnCommand("two_Off")]
    public void twoOff()
    {
        animator.SetBool("isTwo", false);
    } 
    [YarnCommand("thr_On")]
    public void thrOn()
    {
        animator.SetBool("isThr", true);
    }
    [YarnCommand("thr_Off")]
    public void thrOff()
    {
        animator.SetBool("isThr", false);
    }

    //IEnumerator Speak()
    //{
    //    anim.SetBool("isTalking", true);
    //    yield return new WaitForSeconds(1f);
    //    Debug.Log($"{name} is Speaking");
    //    anim.SetBool("isTalking", false);
    //}

    //[YarnCommand("playAnim")] //타임라인 순차 재생...
    //public void playAnim()
    //{
    //    if (Timeline != null)
    //    {
    //        Timeline.gameObject.SetActive(true);
    //        //Timeline[i].SetActive(true);
    //        //Timeline.Play();
    //        //i++;
    //    }
    //}

    [YarnCommand("Move")] //NPC 이동
    public void Move(GameObject destination)
    {
        var position = destination.transform.position;

        animator.SetBool("iswalking", true);
        // walk the character to 'position'
    }
}

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
    public string talkToNode = "";
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
        //if (rend = null;)
        //{
        //    animator.SetBool("isFlip", true);
        //}        
    }

    [YarnCommand("reflip")]
    public void reflip()
    {
        rend.flipX = false;
        //if (rend = null;)
        //{
        //    animator.SetBool("isFlip", false);
        //}
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
    [YarnCommand("zer_On")]
    public void zerOn()
    {
        animator.SetBool("isZer", true);
    }
    [YarnCommand("zer_Off")]
    public void zerOff()
    {
        animator.SetBool("isZer", false);
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
    [YarnCommand("for_On")]
    public void forOn()
    {
        animator.SetBool("isFor", true);
    }
    [YarnCommand("for_Off")]
    public void forOff()
    {
        animator.SetBool("isFor", false);
    }
    [YarnCommand("fiv_On")]
    public void fivOn()
    {
        animator.SetBool("isFiv", true);
    }
    [YarnCommand("fiv_Off")]
    public void fivOff()
    {
        animator.SetBool("isFiv", false);
    }
    [YarnCommand("six_On")]
    public void sixOn()
    {
        animator.SetBool("isSix", true);
    }
    [YarnCommand("six_Off")]
    public void sixOff()
    {
        animator.SetBool("isSix", false);
    }
    [YarnCommand("sev_On")]
    public void sevOn()
    {
        animator.SetBool("isSev", true);
    }
    [YarnCommand("sev_Off")]
    public void sevOff()
    {
        animator.SetBool("isSev", false);
    }
    [YarnCommand("eig_On")]
    public void eigOn()
    {
        animator.SetBool("isEig", true);
    }
    [YarnCommand("eig_Off")]
    public void eigOff()
    {
        animator.SetBool("isEig", false);
    }
    [YarnCommand("nin_On")]
    public void ninOn()
    {
        animator.SetBool("isNin", true);
    }
    [YarnCommand("nin_Off")]
    public void ninOff()
    {
        animator.SetBool("isNin", false);
    }
    [YarnCommand("ten_On")]
    public void tenOn()
    {
        animator.SetBool("isTen", true);
    }
    [YarnCommand("ten_Off")]
    public void tenOff()
    {
        animator.SetBool("isTen", false);
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

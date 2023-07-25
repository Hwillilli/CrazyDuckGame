using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranSFX : MonoBehaviour
{
    public bool destroy = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (destroy == true)
        {
            Invoke("Exit", 3f);
        }
    }

    public void Exit()
    {
        Destroy(gameObject);
    }
}

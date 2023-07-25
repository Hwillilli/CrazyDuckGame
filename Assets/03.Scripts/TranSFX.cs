using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranSFX : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

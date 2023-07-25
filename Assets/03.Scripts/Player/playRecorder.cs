using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRecorder : MonoBehaviour
{
    [SerializeField] private GameObject[] sound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sound[0].SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            sound[0].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sound[1].SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            sound[1].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sound[2].SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            sound[2].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            sound[3].SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            sound[3].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            sound[4].SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            sound[4].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            sound[5].SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            sound[5].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            sound[6].SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            sound[6].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            sound[7].SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            sound[7].SetActive(false);
        }
    }
}

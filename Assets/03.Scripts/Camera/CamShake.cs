using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Yarn.Unity;

public class CamShake : MonoBehaviour
{
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float ShakeIntensity = 1f;
    private float ShakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    // Update is called once per frame
    void Awake()
    {
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    [YarnCommand("Shake")] //카메라 흔들림
    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = ShakeIntensity;

        timer = ShakeTime;
    }
    [YarnCommand("Stop")] //카메라 흔들림
    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                StopShake();
            }
        }
    }

    private void Start()
    {
        StopShake();
    }
}

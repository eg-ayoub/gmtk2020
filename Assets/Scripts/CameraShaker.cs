using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShaker : MonoBehaviour
{

    CinemachineVirtualCamera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    public void Shake()
    {
        // CinemachineBasicMultiChannelPerlin channelPerlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        StartCoroutine(ShakeEnum());
    }

    IEnumerator ShakeEnum()
    {
        CinemachineBasicMultiChannelPerlin channelPerlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        channelPerlin.m_AmplitudeGain = 2;

        yield return new WaitForSecondsRealtime(.45f);

        channelPerlin.m_AmplitudeGain = 0;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicHandler : MonoBehaviour {

    public GameObject laser;

    public static float MicLoudness;

    private string device;

    AudioClip clipRecord;
    int sampleWindow = 128;

    bool isInit;
    void InitMic()
    {
        if(device == null)
        {
            device = Microphone.devices[0];
        }
        clipRecord = Microphone.Start(device, true, 999, 44100);
    }

    void StopMic()
    {
        Microphone.End(device);
    }

    float LevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[sampleWindow];
        int micPos = Microphone.GetPosition(null) - (sampleWindow + 1);
        if(micPos < 0)
        {
            return 0;
        }
        clipRecord.GetData(waveData, micPos);

        for(int i = 0; i < sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if(levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }

        return levelMax;
    }

    void EnableOnLoudEnough(float volume)
    {
        if(volume > 0.035f)
        {
            laser.SetActive(true);
        }else
        {
            laser.SetActive(false);
        }
    }

    void Update()
    {
        MicLoudness = LevelMax();
        Debug.Log(MicLoudness);
        EnableOnLoudEnough(MicLoudness);
    }

    void OnEnable()
    {
        InitMic();
        isInit = true;
    }

    void OnDisable()
    {
        StopMic();
    }

    void OnDestroy()
    {
        StopMic();
    }

    void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            if (isInit)
            {
                InitMic();
                isInit = true;
            }
        }
        if (!focus)
        {
            StopMic();
            isInit = false;
        }
    }
}

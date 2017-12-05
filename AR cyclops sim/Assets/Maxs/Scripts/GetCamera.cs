﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetCamera : MonoBehaviour {

    bool camAvaliable;
    WebCamTexture backCam;
    Texture defaultBackground;

    public GameObject objectToTexture;
    //public RawImage background;
    public AspectRatioFitter fit;

	// Use this for initialization
	void Start () {
        //defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if(devices.Length == 0)
        {
            Debug.Log("No cam found, biatch");
            camAvaliable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
        }

        backCam = new WebCamTexture(devices[0].name, Screen.width, Screen.height);

        if(backCam == null)
        {
            Debug.Log("No back cam found");
            return;
        }

        backCam.Play();

        //background.texture = backCam;

        camAvaliable = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!camAvaliable)
        {
            return;
        }

        objectToTexture.GetComponent<Renderer>().material.mainTexture = backCam;

        float ratio = (float)backCam.width/ (float)backCam.height;
        //fit.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        //background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);


        int orient = -backCam.videoRotationAngle;

        //background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
	}
}

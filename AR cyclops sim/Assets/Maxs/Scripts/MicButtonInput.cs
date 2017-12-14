using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicButtonInput : MonoBehaviour {

    public GameObject laser;
    public AudioClip[] laserSounds;

    AudioSource laserAS;

    float tempPressure;

    float timer;
    float maxTimer;
    float soundTimer;
    // Use this for initialization
    void Start () {
        tempPressure = 0;
        laser.SetActive(false);
        maxTimer = 1.25f;

        laserAS = laser.GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update () {
        
        //For testing in engine.
        /*if (Input.GetKeyDown(KeyCode.Mouse0) && laser.activeInHierarchy == false && timer > maxTimer)
        {
            laser.SetActive(true);
            timer = 0;
        }else if(timer > maxTimer && laser.activeInHierarchy == true)
        {
            laser.SetActive(false);
            timer = 0;
        }*/


        //OnMobile
        if (Input.touchCount > 0 && laser.activeInHierarchy == false && timer > maxTimer)
        {
            laser.SetActive(true);
            timer = 0;
            maxTimer = maxTimer / 2;
        }
        else if (timer > maxTimer && laser.activeInHierarchy == true)
        {
            laser.SetActive(false);
            timer = 0;
            maxTimer = maxTimer * 2;
        }


        //Sound Handling
        if(laser.activeInHierarchy == true)
        {
            if(soundTimer < 0.5f)
            {
                laserAS.clip = laserSounds[0];
            }else
            {
                laserAS.clip = laserSounds[1];
            }

            if (!laserAS.isPlaying)
            {
                laserAS.Play();
            }

            soundTimer += Time.deltaTime;
        }else
        {
            soundTimer = 0;
        }
        timer += Time.deltaTime;
    }
}

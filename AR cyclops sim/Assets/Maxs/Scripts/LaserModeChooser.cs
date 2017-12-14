using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserModeChooser : MonoBehaviour {

    public GameObject player;
    MicButtonInput MBI;
    MicHandler MH;


    float timeSinceTouchPress;
    float timeToModeChange;
    // Use this for initialization
    void Start () {
        MBI = player.GetComponent<MicButtonInput>();
        MH = player.GetComponent<MicHandler>();

        timeToModeChange = 2.25f;

        MH.enabled = false;
        MBI.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceTouchPress += Time.deltaTime;

        if(timeSinceTouchPress > timeToModeChange && Input.touchCount <= 0)
        {
            MBI.enabled = false;
            MH.enabled = true;
        }else if(Input.touchCount > 0)
        {
            MBI.enabled = true;
            MH.enabled = false;
            timeSinceTouchPress = 0;
        }

    }
}

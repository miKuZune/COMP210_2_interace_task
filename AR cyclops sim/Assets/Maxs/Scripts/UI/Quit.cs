using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {


    bool isReady;
	// Use this for initialization
	void Start () {
        isReady = false;
	}
	
    void QuitGame()
    {
        Application.Quit();
    }

	// Update is called once per frame
	void Update () {
        isReady = GetComponent<CheckIfOnLongEnough>().Ready;

        if (isReady)
        {
            QuitGame();
        }
	}
}

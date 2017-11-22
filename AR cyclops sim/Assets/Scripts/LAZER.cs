using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAZER : MonoBehaviour {

    public GameObject lazer;

	// Use this for initialization
	void Start () {
        lazer.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            lazer.SetActive(true);
        }
        else
        {
            //lazer.SetActive(false);
        }
	}
}

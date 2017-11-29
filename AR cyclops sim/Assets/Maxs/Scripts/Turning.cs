using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour {

    public float sensitivity;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	

	// Update is called once per frame
	void Update () {
        transform.Rotate(-Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime, Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime, 0.0f);

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}

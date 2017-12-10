using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfOnLongEnough : MonoBehaviour {

    public float startNumNeeded;
    float startCounter;
    public bool Ready;
    Vector4 colour;
	// Use this for initialization
	void Start () {
        Ready = false;
        colour = new Vector4(0, 0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
        CheckCounter();
	}

    void Increase()
    {
        startCounter += Time.deltaTime;
        colour.x += Time.deltaTime;
        GetComponent<Renderer>().material.color = colour;
    }

    void CheckCounter()
    {
        if(startCounter >= startNumNeeded)
        {
            Ready = true;
        }
    }

    void OnTriggerStay(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Increase();
        }
    }
}

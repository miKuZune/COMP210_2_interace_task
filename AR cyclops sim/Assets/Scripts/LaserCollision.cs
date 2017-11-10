using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour {

    public GameObject UImanager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {

        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            UImanager.GetComponent<Score>().score++;
            UImanager.GetComponent<Score>().UpdateScore();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LaserCollision : MonoBehaviour {

    public GameObject UImanager;
    float score;


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
            if (other.GetComponent<AIwalkTowardPlayer>().health > 0)
            {
                other.GetComponent<AIwalkTowardPlayer>().health = 0;
                score++;
                UImanager.GetComponent<Score>().score++;
            }
            //UImanager.GetComponent<Score>().UpdateScore();
        }

    }
}

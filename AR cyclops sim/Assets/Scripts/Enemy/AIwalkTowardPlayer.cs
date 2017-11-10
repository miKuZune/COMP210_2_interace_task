using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIwalkTowardPlayer : MonoBehaviour {

    public GameObject player;
    public float moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
    void MoveToward()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

	// Update is called once per frame
	void Update () {
        MoveToward();
	}
}

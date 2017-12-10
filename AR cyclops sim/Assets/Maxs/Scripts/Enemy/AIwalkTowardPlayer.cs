using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIwalkTowardPlayer : MonoBehaviour {

    public GameObject player;
    public float moveSpeed;

    public AudioClip walking;
    public AudioClip powerDown;

    public float health;
    float deadTimer;
    AudioSource AS;
	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
        AS.clip = walking;
        deadTimer = 1.5f;
	}
	
    void MoveToward()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    void RotateToward()
    {
        transform.LookAt(player.transform);
    }

    void CheckIfDead()
    {
        if(health <= 0)
        {
            moveSpeed = 0;
            if (!AS.isPlaying)
            {
                AS.clip = powerDown;
                AS.Play();
            }else if(AS.isPlaying && AS.clip == powerDown)
            {
                deadTimer -= Time.deltaTime;
                if (deadTimer < 0)
                {
                    Destroy(this.gameObject);
                }
            }
            
        }
    }

	// Update is called once per frame
	void Update () {
        MoveToward();
        RotateToward();
        CheckIfDead();

        if (!AS.isPlaying && AS.clip != powerDown)
        {
            AS.volume = AS.volume / 3;
            AS.clip = walking;
            AS.Play();
        }
	}
}

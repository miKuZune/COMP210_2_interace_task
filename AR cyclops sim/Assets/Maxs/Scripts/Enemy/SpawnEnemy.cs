using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject enemy;

    private float timer;
    private float spawnTimeMax;
    private float spawnTimeMin;
    private float spawnTime;

    private float maxMoveSpeed;
    private float minMoveSpeed;
	// Use this for initialization
	void Start () {
        spawnTimeMax = 7.5f;
        spawnTimeMin = 1.0f;
        spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);

        maxMoveSpeed = 3.0f;
        minMoveSpeed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer >= spawnTime)
        {
            GameObject current = Instantiate(enemy, transform);
            current.GetComponent<AIwalkTowardPlayer>().moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
            timer = 0;
            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
        }
	}
}

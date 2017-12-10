using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {


    public int health;

    //Material UI vars
    public GameObject[] healthUI;
    public Material redHealth;
    public Material greyHealth;

	// Use this for initialization
	void Start () {
		
	}
	
    void CheckIfDead()
    {
        if(health <= 0)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        //Destroy all enemies.
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i].gameObject);
        }

        //Disable spawners.
        GameObject[] spawners;
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        for(int i = 0; i < spawners.Length; i++)
        {
            spawners[i].GetComponent<SpawnEnemy>().enemy = null;
        }

        GetComponent<Score>().displayText = true;

        //Show UI
    }

	// Update is called once per frame
	void Update () {
        CheckIfDead();
	}
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            healthUI[health - 1].GetComponent<Renderer>().material = greyHealth;
            health--;
            Destroy(coll.gameObject);
        }
    }
}

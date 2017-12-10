using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score;
    public GameObject scoreUI;
    public Transform scoreStartPos;
    public GameObject[] numbers;

    public bool displayText;


    bool hasDisplayed;
	// Use this for initialization
	void Start () {
        scoreUI.SetActive(false);
        //text.text = "Score: 0";
        hasDisplayed = false;
	}
	
    /*public void UpdateScore()
    {
        text.text = "Score: " + score;
    }*/

    GameObject GetNumToSpawn(char num)
    {
        GameObject numToSpawn;
        int number = (int)num - '0';
        numToSpawn = numbers[number];

        return numToSpawn;
    }

    void LayoutScore(int playerScore)
    {
        string sScore = "" + playerScore;
        Vector3 spawnPos = scoreStartPos.position;
        for(int i = 0; i < sScore.Length; i++)
        {
            GameObject toSpawn = GetNumToSpawn(sScore[i]);
            Instantiate(toSpawn, spawnPos, toSpawn.transform.rotation);
            spawnPos.x += 2.75f;
        }
    }

	// Update is called once per frame
	void Update () {
        if (displayText)
        {
            scoreUI.SetActive(true);
            if (!hasDisplayed)
            {
                LayoutScore(score);
                hasDisplayed = true;
            }
        }
	}
}

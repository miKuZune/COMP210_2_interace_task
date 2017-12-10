using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour {

    bool isReady;
    public int sceneToLoad;
    // Use this for initialization
    void Start()
    {
        isReady = false;
    }

    void GoLoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        isReady = GetComponent<CheckIfOnLongEnough>().Ready;

        if (isReady)
        {
            GoLoadScene();
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
            Debug.Log(SceneManager.sceneCount);
            SceneManager.sceneLoaded += this.loadGame;
        }
    }

    void loadGame(Scene scene, LoadSceneMode mode)
    {
        scene = SceneManager.GetActiveScene();
    }
}

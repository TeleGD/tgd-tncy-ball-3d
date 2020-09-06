﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer >= 0.7)
        {
            GetComponent<TextMesh>().text = "Appuyez sur Espace";
        }
        if (timer >= 1.4)
        {
            GetComponent<TextMesh>().text = "";
            timer = 0;
        }
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            SceneManager.sceneLoaded += SceneSwitcher.loadScene;
        }
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
}
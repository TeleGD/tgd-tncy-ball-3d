using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private Scene scene;
    //private bool gameLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Space down");
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
            //gameLoaded = true;
            Debug.Log(SceneManager.sceneCount);
            SceneManager.sceneLoaded += this.loadGame;
        }
        /*if (gameLoaded)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
            scene = SceneManager.GetActiveScene();
            Debug.Log("Active Scene is '" + scene.name + "'.");
        }*/
    }

    void loadGame(Scene scene, LoadSceneMode mode)
    {
        //SceneManager.SetActiveScene(SceneManager.GetSceneAt(0));
        scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
    }
}

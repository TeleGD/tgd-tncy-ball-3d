using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject selectedObject;
    public bool noneSelected = true;
    public Material mat1, mat2;
    public int index = 0;
    public int nbOptions;

    // Start is called before the first frame update
    void Start()
    {
        selectedObject = new GameObject();
        mat1 = Resources.Load<Material>("Unselected");
        mat2 = Resources.Load<Material>("Selected");
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("up") || Input.GetKeyDown("down")) && noneSelected == true)
        {
            selectedObject = GameObject.Find("C1");
            selectedObject.GetComponent<MeshRenderer>().material = mat2;
            noneSelected = false;
        } 
        else if (Input.GetKeyDown("up")) 
        {
            selectedObject.GetComponent<MeshRenderer>().material = mat1;
            index = index - 1;
            if (index < 0) index = index + nbOptions;
            selectedObject = GameObject.Find(string.Concat("C", index + 1));
            selectedObject.GetComponent<MeshRenderer>().material = mat2;
        }
        else if (Input.GetKeyDown("down"))
        {
            selectedObject.GetComponent<MeshRenderer>().material = mat1;
            index = index + 1;
            if (index >= nbOptions) index = index - nbOptions;
            selectedObject = GameObject.Find(string.Concat("C", index + 1));
            selectedObject.GetComponent<MeshRenderer>().material = mat2;
        }
        else if (Input.GetKeyDown("space") && selectedObject == GameObject.Find("C1"))
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
            SceneManager.sceneLoaded += SceneSwitcher.loadScene;
        }
        else if (Input.GetKeyDown("space") && selectedObject == GameObject.Find(string.Concat("C", nbOptions)))
        {
            Application.Quit();
        }
    }
}

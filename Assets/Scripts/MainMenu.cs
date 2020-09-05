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

    Ray ray;
    RaycastHit hit;

    string coll;

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
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            coll = hit.collider.name;
            if (selectedObject.name != coll && noneSelected == false)
            {
                if ((Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0) && coll == "Plane" && Input.GetMouseButtonDown(0)
                    || !(Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0) && !(Input.GetMouseButton(0)) && coll == "Plane")
                {
                    selectedObject.GetComponent<MeshRenderer>().material = mat1;
                    noneSelected = true;
                }
                else if ((Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0) && !(Input.GetMouseButton(0)) && selectedObject.name != coll && coll != "Plane")
                {
                    GameObject.Find(coll).GetComponent<MeshRenderer>().material = mat1;
                }
                else if ((((Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) && !(Input.GetMouseButton(0))) || Input.GetMouseButtonDown(0)) && selectedObject.name != coll && coll != "Plane")
                {
                    selectedObject.GetComponent<MeshRenderer>().material = mat1;
                    index = coll[1] - 48 - 1;
                    select(coll);

                }
            }
            else if ((coll != "Plane" && noneSelected == true && !(Input.GetMouseButton(0)))
                || (selectedObject.name != coll && noneSelected == false))
            {
                index = coll[1] - 48 - 1;
                select(coll);
            }
        }

        if ((Input.GetKeyDown("up") || Input.GetKeyDown("down") || Input.GetKeyDown("z") || Input.GetKeyDown("s")) && noneSelected == true)
        {
            select(string.Concat("C", index + 1));
        } 
        else if (Input.GetKeyDown("up") || Input.GetKeyDown("z"))
        {
            selectedObject.GetComponent<MeshRenderer>().material = mat1;
            index = index - 1;
            if (index < 0) index = index + nbOptions;
            select(string.Concat("C", index + 1));
        }
        else if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
        {
            selectedObject.GetComponent<MeshRenderer>().material = mat1;
            index = index + 1;
            if (index >= nbOptions) index = index - nbOptions;
            select(string.Concat("C", index + 1));
        }
        else if ((Input.GetKeyDown("space") || Input.GetKeyDown("return") || (Input.GetMouseButtonUp(0) && coll == GameObject.Find("C1").name))
            && selectedObject == GameObject.Find("C1"))
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
            SceneManager.sceneLoaded += SceneSwitcher.loadScene;
        }
        else if ((Input.GetKeyDown("space") || Input.GetKeyDown("return") || (Input.GetMouseButtonUp(0) && coll == GameObject.Find(string.Concat("C", nbOptions)).name))
            && selectedObject == GameObject.Find(string.Concat("C", nbOptions)))
        {
            Application.Quit();
        }
    }

    void select(string name)
    {
        selectedObject = GameObject.Find(name);
        selectedObject.GetComponent<MeshRenderer>().material = mat2;
        if (noneSelected == true) noneSelected = false;
    }
}

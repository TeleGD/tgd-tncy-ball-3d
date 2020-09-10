using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamSelector : MonoBehaviour
{

    public GameObject selectedObject;
    public bool noneSelected;
    public Material mat1, mat2, mat3;

    Ray ray;
    RaycastHit hit;

    string coll;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "TeamSelector")
        {
            selectedObject = new GameObject();
            noneSelected = true;
            mat1 = Resources.Load<Material>("Selected");
            mat2 = Resources.Load<Material>("Confirm");
            mat3 = Resources.Load<Material>("Back");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TeamSelector")
        {
            // Check mouse controls
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                coll = hit.collider.name;
                if (selectedObject.name != coll && noneSelected == false)
                {
                    if ((Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0) && !(coll == "Forward" || coll == "Backward") && Input.GetMouseButtonDown(0)
                        || !(Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0) && !(Input.GetMouseButton(0)) && !(coll == "Forward" || coll == "Backward"))
                    {
                        if (selectedObject.name == "Forward")
                        {
                            selectedObject.GetComponent<MeshRenderer>().material = mat2;
                        }
                        else if (selectedObject.name == "Backward")
                        {
                            selectedObject.GetComponent<MeshRenderer>().material = mat3;
                        }
                        noneSelected = true;
                    }
                    else if ((Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") == 0) && !(Input.GetMouseButton(0)) && (coll == "Forward" || coll == "Backward"))
                    {
                        if (coll == "Forward")
                        {
                            GameObject.Find(coll).GetComponent<MeshRenderer>().material = mat2;
                        }
                        else if (coll == "Backward")
                        {
                            GameObject.Find(coll).GetComponent<MeshRenderer>().material = mat3;
                        }

                    }
                    else if ((((Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) && !(Input.GetMouseButton(0))) || Input.GetMouseButtonDown(0)) && (coll == "Forward" || coll == "Backward"))
                    {
                        if (selectedObject.name == "Forward")
                        {
                            selectedObject.GetComponent<MeshRenderer>().material = mat2;
                        }
                        else if (selectedObject.name == "Backward")
                        {
                            selectedObject.GetComponent<MeshRenderer>().material = mat3;
                        }
                        select(coll);

                    }
                }
                else if ((coll == "Forward" || coll == "Backward") && noneSelected == true && !(Input.GetMouseButton(0)))
                {
                    select(coll);
                }
            }

            // Check mouse and keyboard controls
            if (Input.GetKeyDown("space") || Input.GetKeyDown("return") || (Input.GetMouseButtonUp(0) && coll == GameObject.Find("Forward").name && selectedObject == GameObject.Find("Forward")))
            {
                SceneManager.LoadScene("Game", LoadSceneMode.Single);
                PlayerController.quick = false;
                SceneManager.sceneLoaded += SceneSwitcher.loadScene;
            }
            else if (Input.GetKeyDown("escape") || Input.GetKeyDown("return") || (Input.GetMouseButtonUp(0) && coll == GameObject.Find("Backward").name && selectedObject == GameObject.Find("Backward")))
            {
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                SceneManager.sceneLoaded += SceneSwitcher.loadScene;
            }
        }
            


    }

    void select(string name)
    {
        selectedObject = GameObject.Find(name);
        selectedObject.GetComponent<MeshRenderer>().material = mat1;
        if (noneSelected == true) noneSelected = false;
    }

}

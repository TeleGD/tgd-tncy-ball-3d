using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamSwitcher : MonoBehaviour
{
    public Material mat1, mat2;

    Ray ray;
    RaycastHit hit;

    Collider coll;
    string selected;

    public string q, d;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "TeamSelector")
        {
            timer = 0;
            mat1 = Resources.Load<Material>("Arrow");
            mat2 = Resources.Load<Material>("GoldenArrow");
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
                coll = hit.collider;
            }

                if (timer >= 0.2)
            {
                gameObject.transform.GetChild(1).Find(selected).GetComponent<MeshRenderer>().material = mat1;
                timer = 0;
            }
            else if (timer > 0)
            {
                timer = timer + Time.deltaTime;
            }
            else if (Input.GetKeyDown(q) || (Input.GetMouseButtonUp(0) && coll.name == "Left" && gameObject.name == coll.gameObject.transform.parent.parent.name))
            {
                // TO-DO INSTEAD OF PRINT LINE
                print(string.Concat("Change team - left - ", gameObject.name));
                gameObject.transform.GetChild(1).Find("Left").GetComponent<MeshRenderer>().material = mat2;
                selected = "Left";
                timer = timer + Time.deltaTime;
            }
            else if (Input.GetKeyDown(d) || (Input.GetMouseButtonUp(0) && coll.name == "Right" && gameObject.name == coll.gameObject.transform.parent.parent.name))
            {
                // TO-DO INSTEAD OF PRINT LINE
                print(string.Concat("Change team - right - ", gameObject.name));
                gameObject.transform.GetChild(1).Find("Right").GetComponent<MeshRenderer>().material = mat2;
                selected = "Right";
                timer = timer + Time.deltaTime;
            }

        }
    }

}

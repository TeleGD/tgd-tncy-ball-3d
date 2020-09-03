using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
    }
}

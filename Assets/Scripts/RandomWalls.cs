using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalls : MonoBehaviour
{
    void Start()
    {
        if (transform.childCount < 3)
            return;

        transform.GetChild(0).Translate(Vector3.right * Random.Range(-30, 30) / 10f);
        transform.GetChild(1).Translate(Vector3.right * Random.Range(-30, 30) / 10f);
        transform.GetChild(2).Translate(Vector3.forward * Random.Range(-30, 30) / 10f);
        transform.GetChild(3).Translate(Vector3.forward * Random.Range(-30, 30) / 10f);
    }
}

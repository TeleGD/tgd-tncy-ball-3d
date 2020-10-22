using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorColor : MonoBehaviour
{
    public Material[] colors;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).Find("Spectator").GetComponent<MeshRenderer>().material = colors[Random.Range(0, 2)];
    }
}

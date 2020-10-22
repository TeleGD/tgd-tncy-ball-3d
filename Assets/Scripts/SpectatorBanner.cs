using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorBanner : MonoBehaviour
{
    public Material[] colors;

    // Start is called before the first frame update
    void Start()
    {
        int idPlayer = Random.Range(0, 2);
        
        transform.GetChild(0).Find("Logo").GetComponent<MeshRenderer>().material.mainTexture = TeamSelector.GetSelection(idPlayer).GetLogo();
        transform.GetChild(0).Find("Spectator").GetComponent<MeshRenderer>().material = colors[idPlayer];
    }

}

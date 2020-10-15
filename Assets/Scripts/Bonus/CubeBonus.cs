using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBonus : Bonus
{
    /*
     * La balle est transformée en cube
     */

    public Mesh cubeMesh; //cube par défaut de Unity
    public Mesh sphereMesh; //uv_sphere : modèle de base de la balle

    public override void OnPick(Collider collider)
    {
        Ball.instance.GetComponent<MeshFilter>().mesh = cubeMesh;
        Ball.instance.gameObject.AddComponent<BoxCollider>();
    }

    public override void End()
    {
        Ball.instance.GetComponent<MeshFilter>().mesh = sphereMesh;
        Destroy(Ball.instance.GetComponent<BoxCollider>());
    }

}

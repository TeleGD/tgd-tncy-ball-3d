using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBonus : Bonus
{
    public Mesh cube;
    public Mesh sphere;

    public override void OnPick(Collider collider)
    {
        Ball.instance.GetComponent<MeshFilter>().mesh = cube;
        Ball.instance.GetComponent<BoxCollider>().enabled = true;
    }

    public override void End()
    {
        Ball.instance.GetComponent<MeshFilter>().mesh = sphere;
        Ball.instance.GetComponent<BoxCollider>().enabled = false;
    }
}

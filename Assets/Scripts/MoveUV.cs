using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUV : MonoBehaviour
{
    private MeshRenderer mr;
    public Vector2 offset;
    private Vector2 pos;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        pos += offset * Time.deltaTime;
        mr.material.SetTextureOffset("_MainTex", new Vector2(pos.x, pos.y));
    }
}

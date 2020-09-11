using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectators : MonoBehaviour
{
    public GameObject spectatorPrefab;

    void Start()
    {
        SpawnSpectator(0, 2, 0, 0);
        SpawnSpectator(3, 5, 0, 0);
        SpawnSpectator(0, 2, 0.6f, 1.3f);
        SpawnSpectator(4, 5, 0.6f, 1.3f);
    }

    private void SpawnSpectator(float minX, float maxX, float y, float z)
    {
        Vector3 pos = transform.position + transform.rotation
            * new Vector3(Random.Range(minX * 10, maxX * 10) / 10f, y, z);
        Instantiate(spectatorPrefab, pos, transform.rotation, transform);
    }
    
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetChild(0).localPosition = Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 6 + i) * 0.4f);
        }
    }
}

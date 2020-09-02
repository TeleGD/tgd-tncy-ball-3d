using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody body;
    public static Ball instance;

    private void Start()
    {
        instance = this;
        body = GetComponent<Rigidbody>();
        Reset();
    }

    public void Reset()
    {
        transform.position = Vector3.up;
        body.velocity = Vector3.up * 5;
        body.angularVelocity = Vector3.zero;
    }
}

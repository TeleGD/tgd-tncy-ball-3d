using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    /*
    private Rigidbody body;
    private Rigidbody target;
    private Vector3 targetOffset;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        body.velocity = Vector3.up * 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            target = collision.rigidbody;
            targetOffset = GameManager.FlattenVector(body.position - target.position).normalized + (Vector3.up * 0.3f);
        }
        else if (target != null)
            ReleaseBall();
    }

    public void ReleaseBall()
    {
        target = null;
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            body.MovePosition(target.position + targetOffset + (target.velocity * Time.fixedDeltaTime));
            body.velocity = target.velocity;

            if (target.velocity.sqrMagnitude < 10 || Vector3.Angle(targetOffset, target.velocity) > 110)
                ReleaseBall();
        }
    }
    */
}

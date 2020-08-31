using System.Security;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerID = 1; //1 ou 2

    private Rigidbody body;
    public float speed = 100;
    public float friction = 10;

    private Vector3 dir;
    private string horizontalAxis, verticalAxis;

    private void Start()
    {
        body = GetComponent<Rigidbody>();

        horizontalAxis = "Horizontal" + playerID;
        verticalAxis = "Vertical" + playerID;
    }

    private void Update()
    {
        //if (!GameManager.gameStarted)
        //    return;

        //animation du joueur
        //transform.GetChild(0).localEulerAngles = new Vector3(-body.velocity.z, 0, body.velocity.x) * 4;

        if(dir.sqrMagnitude > 0.1f)
        {
            Quaternion targetRot = Quaternion.Euler(0, Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, 0);
            body.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 1000 * Time.deltaTime);
        }
        
    }
    private void FixedUpdate()
    {
        //if (!GameManager.gameStarted)
        //    return;

        dir = new Vector3(Input.GetAxis(horizontalAxis), 0, Input.GetAxis(verticalAxis));
        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        body.AddForce(dir * speed, ForceMode.Acceleration);
        body.AddForce(GameManager.FlattenVector(-body.velocity * friction), ForceMode.Acceleration);
    }
}
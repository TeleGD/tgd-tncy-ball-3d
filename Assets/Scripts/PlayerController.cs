using System.Security;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerID = 1; //1 ou 2

    private Rigidbody body;
    public float speed = 100;
    public float friction = 10;

    private Vector3 dir;
    private string horizontalAxis, verticalAxis, dashButton;

    public float dashCooldown = 1;
    private float lastDashTime;

    private Vector3 startPos;
    private float startAngle;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        startPos = transform.position;
        startAngle = transform.eulerAngles.y;

        horizontalAxis = "Horizontal" + playerID;
        verticalAxis = "Vertical" + playerID;
        dashButton = "Dash" + playerID;
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

        if (Input.GetButtonDown(dashButton) && body.velocity.sqrMagnitude > 1 && lastDashTime + dashCooldown < Time.time)
        {
            body.AddForce(body.velocity.normalized * speed * 15, ForceMode.Acceleration);
            lastDashTime = Time.time;
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
        body.AddForce(GameManager.FlattenVector(-body.velocity * GetFriction()), ForceMode.Acceleration);
    }

    private float GetFriction()
    {
        return (lastDashTime < Time.time + 0.5f) ? friction : friction * 0.4f;
    }

    public void ResetPos()
    {
        transform.position = startPos;
        transform.eulerAngles = Vector3.up * startAngle;
    }
}
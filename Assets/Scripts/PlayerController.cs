
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

    public ParticleSystem smokeParticles;

    public static bool quick = true;

    private void Start()
    {
        System.Random r = new System.Random();
        int i1 = r.Next(TeamWheel.teams.Count - 1);
        int i2 = r.Next(TeamWheel.teams.Count - 1);
        if (playerID == 1)
        {
            if (quick)
            {
                this.gameObject.transform.GetChild(0).Find("Logo").GetComponent<MeshRenderer>().material = Resources.Load<Material>("Logos/Logo1");
            }
            else
            {
                this.gameObject.transform.GetChild(0).Find("Logo").GetComponent<MeshRenderer>().material = TeamWheel.logo1;
            }
            if (this.gameObject.transform.GetChild(0).Find("Logo").GetComponent<MeshRenderer>().material.mainTexture == Resources.Load<Texture>("Logos/random"))
            {
                this.gameObject.transform.GetChild(0).Find("Logo").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", Resources.Load<Texture>(string.Concat("Logos/", TeamWheel.teams[i1].getFileId())));
            }
        }
        if (playerID == 2)
        {
            if (quick)
            {
                this.gameObject.transform.GetChild(0).Find("Logo").GetComponent<MeshRenderer>().material = Resources.Load<Material>("Logos/Logo2");
            }
            else
            {
                this.gameObject.transform.GetChild(0).Find("Logo").GetComponent<MeshRenderer>().material = TeamWheel.logo2;
            }
            if (this.gameObject.transform.GetChild(0).Find("Logo").GetComponent<MeshRenderer>().material.mainTexture == Resources.Load<Texture>("Logos/random"))
            {
                this.gameObject.transform.GetChild(0).Find("Logo").GetComponent<MeshRenderer>().material.SetTexture("_MainTex", Resources.Load<Texture>(string.Concat("Logos/", TeamWheel.teams[i2].getFileId())));
            }
        }

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

        float currentSpeed = dir.sqrMagnitude;
        if(currentSpeed > 0.1f)
        {
            Quaternion targetRot = Quaternion.Euler(0, Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, 0);
            body.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 1000 * Time.deltaTime);

            if (Input.GetButtonDown(dashButton) && body.velocity.sqrMagnitude > 1 && lastDashTime + dashCooldown < Time.time)
            {
                body.AddForce(body.velocity.normalized * speed * 15, ForceMode.Acceleration);
                lastDashTime = Time.time;
            }

            if(lastDashTime + 0.5f > Time.time )
            {
                transform.GetChild(0).localEulerAngles = Vector3.right * -30;
            }
            else
            {
                transform.GetChild(0).localPosition = Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 10) * 0.15f);
                transform.GetChild(0).localEulerAngles = Vector3.forward * (Mathf.Cos(Time.time * 10) * 5);
            }
        }
        else
        {
            transform.GetChild(0).localPosition = Vector3.zero;
            transform.GetChild(0).localEulerAngles = Vector3.zero;
        }

        ParticleSystem.EmissionModule emission = smokeParticles.emission;
        float smokeAmount = currentSpeed > 0.1f ? 15f : 0;
        emission.rateOverTime = smokeAmount;
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
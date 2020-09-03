using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 startAngle;

    private void Start()
    {
        startPos = transform.position;
        startAngle = transform.eulerAngles;
    }

    void Update()
    {
        Vector3 targetPos = Vector3.zero;
        Quaternion targetRot = Quaternion.identity;

        if(!GameManager.instance.AreGoalsLocked())
        {
            float h = Ball.instance.transform.position.z;
            targetPos = startPos + Vector3.forward * (h * h * 0.03f);
            targetRot = Quaternion.Euler(startAngle - Vector3.right * (h * 0.6f));
        }
        else //équipe qui vient de prendre un but
        {
            int team = GameManager.instance.GetLastTeamGoal();
            Vector3 goalPos = GameObject.Find("Goal " + team).transform.position;
            targetPos = Ball.instance.transform.position + new Vector3((team == 1 ? 5 : -5), 2, -2);
            targetRot = Quaternion.LookRotation(goalPos - targetPos);
        }
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 5);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * 5);
    }
}

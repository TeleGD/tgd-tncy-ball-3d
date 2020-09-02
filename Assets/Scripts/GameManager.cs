using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int Oscore=0;
    int Bscore=0;
    private bool lockGoal = false;
    private Vector3 cameraStartPos;
    private Quaternion cameraStartRot;

    public static GameManager instance;

    void Start()
    {
        instance = this;
        cameraStartPos = Camera.main.transform.position;
        cameraStartRot = Camera.main.transform.rotation;
    }

    public static Vector3 FlattenVector(Vector3 vec)
    {
        return new Vector3(vec.x, 0, vec.z);
    }

    public void EndRound(int id)
    {
        if (lockGoal)
            return;
        lockGoal = true;

        if(id == 1)
            Bscore+=1;
        else
            Oscore+=1;

        Debug.Log(Oscore+"||"+Bscore);

        Camera.main.GetComponent<Animation>().enabled = true;
        Camera.main.GetComponent<Animation>().Play();

        StartCoroutine(Reset(2));
    }

    IEnumerator Reset(int delay)
    {
        yield return new WaitForSeconds(delay);
        Ball.instance.Reset();
        GameObject.Find("P1").GetComponent<PlayerController>().ResetPos();
        GameObject.Find("P2").GetComponent<PlayerController>().ResetPos();
        Camera.main.GetComponent<Animation>().enabled = false;
        Camera.main.transform.SetPositionAndRotation(cameraStartPos, cameraStartRot);
        Camera.main.fieldOfView = 60;
       lockGoal = false;
    }
}

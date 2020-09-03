using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int Oscore=0;
    int Bscore=0;
    private bool lockGoal = false;
    private int lastTeamGoal = 1;
    public TextMesh scoreDisplay;

    public static GameManager instance;

    void Start()
    {
        instance = this;
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
        lastTeamGoal = id;

        if(id == 1)
            Oscore++;
        else
            Bscore++;

        scoreDisplay.text = Bscore + " - " + Oscore;

        StartCoroutine(Reset(3));
    }

    IEnumerator Reset(int delay)
    {
        yield return new WaitForSeconds(delay);
        Ball.instance.Reset();
        GameObject.Find("P1").GetComponent<PlayerController>().ResetPos();
        GameObject.Find("P2").GetComponent<PlayerController>().ResetPos();
        lockGoal = false;
    }

    public bool AreGoalsLocked()
    {
        return lockGoal;
    }

    public int GetLastTeamGoal()
    {
        return lastTeamGoal;
    }
}

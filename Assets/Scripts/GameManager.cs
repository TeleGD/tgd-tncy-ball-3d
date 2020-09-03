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

    public GameObject bonusPrefab;
    public string[] bonusClasses;
    public float bonusDelay = 3;

    void Start()
    {
        instance = this;
        StartCoroutine(SpawnBonusLoop());
    }

    IEnumerator SpawnBonusLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(bonusDelay);
            SpawnBonus();
        }
    }

    private void SpawnBonus()
    {
        Vector3 pos = new Vector3(Random.Range(-100, 100) / 10f, 0.5f, Random.Range(-80, 80) / 10f);
        GameObject go = Instantiate(bonusPrefab, pos, Quaternion.identity);
        System.Type bonusType = System.Type.GetType(bonusClasses[Random.Range(0, bonusClasses.Length)]);
        go.AddComponent(bonusType);
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

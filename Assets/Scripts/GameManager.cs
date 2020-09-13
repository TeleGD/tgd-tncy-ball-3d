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

    public GameObject[] bonusPrefab;
    public float bonusDelay = 10;
    public float bonusRandomFactor = 0.3f;

    void Start()
    {
        instance = this;
        StartCoroutine(SpawnBonusLoop());
    }

    IEnumerator SpawnBonusLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(bonusDelay*(1-bonusRandomFactor), bonusDelay*(1+bonusRandomFactor)));
            SpawnBonus();
        }
    }

    private void SpawnBonus()
    {
        Vector3 pos = new Vector3(Random.Range(-100, 100) / 10f, 0.5f, Random.Range(-80, 80) / 10f);
        GameObject go = Instantiate(bonusPrefab[Random.Range(0, bonusPrefab.Length)], pos, Quaternion.identity);
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

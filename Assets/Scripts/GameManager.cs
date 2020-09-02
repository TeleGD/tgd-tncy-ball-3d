using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int Oscore=0;
    int Bscore=0;
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

        if(id==0){
            Bscore+=1;
        }else{
            Oscore+=1;
        }
        Debug.Log(Oscore+"||"+Bscore);
        StartCoroutine(DelayedEnd(3));
    }

    IEnumerator DelayedEnd(int i)
    {
        yield return new WaitForSeconds(i);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

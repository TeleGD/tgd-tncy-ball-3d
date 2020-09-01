using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    [SerializeField] private float duration = 5f;
    private float timer;
    private bool taken;

    private void Start()
    {
        timer = duration;
        taken = false;
    }

    private void Update()
    {
        System.Console.WriteLine(taken);
        if (taken)
        {
            if (timer<=0)
            {
                End();
                Object.Destroy(this.gameObject);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        OnPick(collider);
        taken = true;
        this.gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.GetComponent<Collider>().enabled = false;
    }

    public abstract void OnPick(Collider collider);
    public abstract void End();

}

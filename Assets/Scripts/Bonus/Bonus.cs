using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    /* Cette classe abstraite représente un bonus.
     * Lorsque le bonus est touché par un joueur, il n'apparait plus dans le jeu,
     * et la fonction 'OnPick' est appelée, et un timer est lancé.
     * Après un nombre de secondes indiqué par la variable 'duration', la fonction 'End' est 
     * appelée, puis l'objet est détruit.
     */

    [SerializeField] protected float duration = 5f;
    protected float timer;
    protected bool taken;

    protected void Start()
    {
        timer = duration;
        taken = false;
    }

    protected void Update()
    {
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
        if (collider.CompareTag("Player"))
        {
            OnPick(collider);
            taken = true;
            this.gameObject.GetComponent<Renderer>().enabled = false;
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    public abstract void OnPick(Collider collider);
    public abstract void End();

}

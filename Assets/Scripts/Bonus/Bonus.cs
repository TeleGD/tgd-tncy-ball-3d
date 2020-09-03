﻿using System.Collections;
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
    protected bool taken = false;
    protected Color color;

    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            OnPick(collider);
            taken = true;
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Invoke("DestroyBonus", duration);
        }
    }

    private void DestroyBonus()
    {
        End();
        Destroy(gameObject);
    }

    public abstract void OnPick(Collider collider);
    public abstract void End();

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody body;
    public static Ball instance;
    private static float maxSuper = 1f; // borne max du combo
    private static float minSuper = 0.1f; // borne min du combo
    private float lastContact; // durée du dernier contact avec un joueur
    private float combo = 0;

    private void Start()
    {
        instance = this;
        body = GetComponent<Rigidbody>();
        Reset();
    }

    public void Reset()
    {
        transform.position = Vector3.up;
        body.velocity = Vector3.up * 5;
        body.angularVelocity = Vector3.zero;
        lastContact = Time.time;
    }

    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Player")){
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if(player.wasDashing && IsSuper()){
                combo++;
                body.velocity = body.velocity * combo * 5;
                player.dashCooldown = 0; // va permettre au joueur d'enchainer les dash
            }
            else{combo = 0;}
            lastContact = Time.time;
        }
    }
    public bool IsSuper(){
        // Etat dans lequel la balle peut être comboté
        return minSuper <= Time.time-lastContact  && Time.time-lastContact<= maxSuper;
    }

}

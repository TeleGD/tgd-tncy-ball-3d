using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMalus : Bonus
{
    /* Malus de vitesse donné au joueur.
     * La vitesse est divisée par 'speedfactor'
     */

    private void Awake()
    {
        color = new Color(0.1f, 0.1f, 0.2f);
    }

    [SerializeField] private float speedFactor = 2.0f;
    private PlayerController controll;

    public override void OnPick(Collider collider)
    {
        controll = collider.gameObject.GetComponent<PlayerController>();
        controll.speed /= speedFactor;
    }

    public override void End()
    {
        controll.speed *= speedFactor;
    }

}

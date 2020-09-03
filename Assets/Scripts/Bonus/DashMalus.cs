using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMalus : Bonus
{
    /* Malus de dash donné au joueur.
     * Le cooldown est multiplié par 'dashCooldownFactor'.
     */

    [SerializeField] private float dashCooldownFactor = 2.0f;
    private PlayerController controll;

    private void Awake()
    {
        color = new Color(1, 0.5f, 0);
    }

    public override void OnPick(Collider collider)
    {
        controll = collider.GetComponent<PlayerController>();
        controll.dashCooldown *= dashCooldownFactor;
    }

    public override void End()
    {
        controll.dashCooldown /= dashCooldownFactor;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : Bonus
{
    [SerializeField] private float speedFactor = 2.0f;
    private PlayerController controll;
    private float resetValue;

    public override void OnPick(Collider collider)
    {
        controll = collider.gameObject.GetComponent<PlayerController>();
        resetValue = controll.speed;
        controll.speed *= speedFactor;
    }

    public override void End()
    {
        controll.speed = resetValue;
    }

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityBonus : Bonus
{
    public Material transparent;
    public Material ball;

    public override void OnPick(Collider collider)
    {
        Ball.instance.GetComponent<Renderer>().material = transparent;
    }

    public override void End()
    {
        Ball.instance.GetComponent<Renderer>().material = ball;
    }
}

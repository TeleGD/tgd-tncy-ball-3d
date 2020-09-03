using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantBallBonus : Bonus
{
    /* Malus de vitesse donné au joueur.
     * La vitesse est divisée par 'speedfactor'
     */

    private void Awake()
    {
        color = new Color(1f, 1f, 0);
    }

    private float scaleFactor = 2.0f;

    public override void OnPick(Collider collider)
    {
		Ball.instance.transform.localScale = Ball.instance.transform.localScale * scaleFactor;
    }

    public override void End()
    {
		Ball.instance.transform.localScale = Ball.instance.transform.localScale / scaleFactor;

	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantBallBonus : Bonus
{
    /* Malus de vitesse donné au joueur.
     * La vitesse est divisée par 'speedfactor'
     */

    public float scaleFactor = 2.0f;

    public override void OnPick(Collider collider)
    {
		Ball.instance.transform.localScale = Ball.instance.transform.localScale * scaleFactor;
        Vector3 pos = Ball.instance.transform.position;
        pos.y = Mathf.Max(pos.y, Ball.instance.transform.localScale.y / 2f);
        Ball.instance.transform.position = pos;
    }

    public override void End()
    {
		Ball.instance.transform.localScale = Ball.instance.transform.localScale / scaleFactor;

	}

}

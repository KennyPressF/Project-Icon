using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerHealth : NPC_Base
{
    public override void GainHealth(float healthToGain)
    {
        base.GainHealth(healthToGain);
    }

    public override void LoseHealth(float healthToLose)
    {
        base.LoseHealth(healthToLose);
    }

    public override void Die()
    {
        base.Die();
    }
}
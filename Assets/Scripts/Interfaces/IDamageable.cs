using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void GainHealth(float healthToGain);
    public void LoseHealth(float healthToLose);
    public void Die();
}

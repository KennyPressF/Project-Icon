using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC_Base : MonoBehaviour, IDamageable
{
    private float currentHealth;
    private float maxHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log(currentHealth);
    }

    public virtual void GainHealth(float healthToGain)
    {
        currentHealth += healthToGain;
        Debug.Log(currentHealth);
    }

    public virtual void LoseHealth(float healthToLose)
    {
        currentHealth -= healthToLose;
        Debug.Log(currentHealth);
    }

    public virtual void Die()
    {

    }
}

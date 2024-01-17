using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour, IDamageable
{
    [SerializeField] float currentHealth;
    float maxHealth = 100f;

    [SerializeField] GameObject meatPrefab;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeCurrentHealth(bool healthGained, float healthValue)
    {
        currentHealth = healthGained ? currentHealth += healthValue : currentHealth -= healthValue;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(meatPrefab);
        Destroy(gameObject);
    }
}

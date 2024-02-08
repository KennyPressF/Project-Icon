using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGameObject : MonoBehaviour
{
    private Vector2 travelDir /*= Vector2.up*/;
    private float travelSpeed /*= 2f*/;
    private float damageToDeal;

    private void OnEnable()
    {
        
    }

    private void Update()
    {
        ProcessMovement();
    }

    public void SetValues(Vector2 td, float ts, float dmg)
    {
        travelDir = td;
        travelSpeed = ts;
        damageToDeal = dmg;
    }

    private void ProcessMovement()
    {
        transform.Translate(travelDir * travelSpeed * Time.deltaTime);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    IDamageable damageInterface = collision.GetComponent<IDamageable>();

    //    if (damageInterface != null)
    //    {
    //        damageInterface.LoseHealth(damageToDeal);
    //    }
    //}

    //WHICH ONE?

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageInterface = collision.gameObject.GetComponent<IDamageable>();

        if (damageInterface != null)
        {
            damageInterface.LoseHealth(damageToDeal);
        }
    }
}

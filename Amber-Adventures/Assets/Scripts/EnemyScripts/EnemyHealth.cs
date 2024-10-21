using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public bool CanTakeDamage;
    public Transform deathFX;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        EnemyDeath();
    }

    public void TakeDamage(float damageToApply)
    {
        if (CanTakeDamage == true)
        {
            currentHealth -= damageToApply;
        }
    }

    public void GainHealth(float healthToGain)
    {
        currentHealth += healthToGain;
    }

    public void EnemyDeath()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Enemy Has Died!");
            Instantiate(deathFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        PlayerDeath();
    }

    public void TakeDamage(float damageToApply)
    {
        currentHealth -= damageToApply;
    }

    public void GainHealth(float healthToGain)
    {
        currentHealth += healthToGain;
    }

    public void PlayerDeath()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Player Has Died!");
        }
    }
}

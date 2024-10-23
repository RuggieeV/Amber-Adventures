using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public AudioSource PlayerHurt;

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
        //PlayerHurt.Play();
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

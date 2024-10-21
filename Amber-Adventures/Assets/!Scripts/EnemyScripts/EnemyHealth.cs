using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public bool CanTakeDamage;
    public Transform deathFX;
    public AudioSource HitSound;
    public AudioSource DeathSound;

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
            HitSound.Play();
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
            DeathSound.Play();
            Instantiate(deathFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

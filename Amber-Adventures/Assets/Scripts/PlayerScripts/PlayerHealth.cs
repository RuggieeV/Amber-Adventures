using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    void TakeDamage(float damageToApply)
    {
        currentHealth -= damageToApply;
    }

    void GainHealth(float healthToGain)
    {
        currentHealth += healthToGain;
    }
}

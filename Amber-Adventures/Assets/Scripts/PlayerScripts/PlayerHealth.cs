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

    public void TakeDamage(float damageToApply)
    {
        currentHealth -= damageToApply;
    }

    public void GainHealth(float healthToGain)
    {
        currentHealth += healthToGain;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEnemyAttack : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth targethealth = collision.GetComponent<PlayerHealth>();
            targethealth.TakeDamage(damage);
        }
    }
}


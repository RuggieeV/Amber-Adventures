using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPlayerAttack : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth targetHealth = collision.GetComponent<EnemyHealth>();
            targetHealth.TakeDamage(damage);
        }
    }
}

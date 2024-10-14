using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPlayerAttack : MonoBehaviour
{
    public float damage;
    public float destroyTime;
    private bool beenHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && beenHit == false)
        {
            EnemyHealth targetHealth = collision.GetComponent<EnemyHealth>();
            targetHealth.TakeDamage(damage);
            beenHit = true;
        }
    }

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}

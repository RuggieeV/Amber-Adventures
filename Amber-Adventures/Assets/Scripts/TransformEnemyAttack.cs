using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEnemyAttack : MonoBehaviour
{
    public float damage;
    private PlayerHealth targethealth;
    

    private void Start()
    {
        targethealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targethealth.TakeDamage(damage) ;
        }
    }


}

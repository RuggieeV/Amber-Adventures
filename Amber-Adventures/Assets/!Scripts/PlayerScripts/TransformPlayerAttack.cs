using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class TransformPlayerAttack : MonoBehaviour
{
    public float damage;
    public int hitCount;
    public Transform hitFX;
    public AudioSource HitSound;
    public float destroyTime;
    public float speed;

    private float cooldownTimer;

    private void OnTriggerStay2D(Collider2D collision)
    {

         if (collision.CompareTag("Enemy") && cooldownTimer <= 0)
         {
            Instantiate(hitFX, collision.transform.position, collision.transform.rotation); //HitFX spawns at the collision
            EnemyHealth targetHealth = collision.GetComponent<EnemyHealth>();               //Grabs Enemy Health
            targetHealth.TakeDamage(damage);                                                //Deals damage
            cooldownTimer = destroyTime / hitCount;                                         //Splits hits into equal intervals
            //HitSound.Play();
         }
    }

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}

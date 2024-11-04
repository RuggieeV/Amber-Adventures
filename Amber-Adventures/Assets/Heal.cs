using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float healAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            PlayerHealth playerhealth = collision.GetComponent<PlayerHealth>();
            playerhealth.GainHealth(healAmount);
            Destroy(this.gameObject);
        }
    }
}
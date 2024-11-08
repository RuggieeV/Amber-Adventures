using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public AudioSource PlayerHurt;
    public Image HealthBar;
    [SerializeField] TextMeshProUGUI TextMaxHealth;
    [SerializeField] TextMeshProUGUI TextCurrentHealth;
    

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        HealthBar.fillAmount = currentHealth / maxHealth;
        TextMaxHealth.text = maxHealth.ToString();
        TextCurrentHealth.text = currentHealth.ToString();
    }

    private void FixedUpdate()
    {
        PlayerDeath();
    }

    public void TakeDamage(float damageToApply)
    {
        currentHealth -= damageToApply;
        PlayerHurt.Play();
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 20;  
    private int currentHealth;    
    [SerializeField] private TMP_Text healthText;         

    private void Start()
    {
        currentHealth = maxHealth; 
        UpdateHealthText();         
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = "HP: " + currentHealth.ToString();
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int budget = 300;
    public TMP_Text budgetText;
    private int currentBudget;

    public int CurrentBudget => currentBudget;


    [SerializeField] private int maxHealth = 20;
    private int currentHealth;
    [SerializeField] private TMP_Text healthText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateBudgetUI();
        currentHealth = maxHealth;
        UpdateHealthText();
        Debug.Log("Start budget: $" + budget);

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
    public bool SpendBudget(int amount)
    {
        if (budget >= amount)
        {
            budget -= amount;
            UpdateBudgetUI();
            Debug.Log("Remaining budget: $" + budget);
            return true;
        }
        else
        {
            Debug.Log("not enough budget");
            return false;
        }
    }
    public void AddCoins(int amount)
    {
        budget += amount;
        UpdateBudgetUI();
        Debug.Log("current $" + budget);
    }


    public void UpdateBudgetUI()
    {
        budgetText.text = budget.ToString();
    }
    private void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString();

    }
    private void GameOver()
    {
        Debug.Log("Oyun Bitti!");
    }
}

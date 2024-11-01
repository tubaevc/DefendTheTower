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
        Debug.Log("Start budget: $" + budget);

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
}

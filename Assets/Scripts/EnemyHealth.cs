using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 15;
    [SerializeField]private Animator animator;
    [SerializeField] private int damageToPlayer = 1;
    [SerializeField] private int coinValue = 10;
    private GameManager gameManager;
    private void Start()
    {
        gameManager =GameManager.Instance;
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            animator.SetTrigger("Hit");
            Debug.Log("hit");
        }
    }

    public void Die()
    {
        animator.SetTrigger("Die");
        Debug.Log("die");
        if (gameManager != null)
        {
            gameManager.AddCoins(coinValue);
            Debug.Log("collected ");
        }
        Destroy(gameObject, 1f); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageToPlayer);
            }
            Destroy(gameObject); 
        }
    }
}

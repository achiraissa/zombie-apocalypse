using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{   
    public int maxHealth = 100;
    public int currentHealth;

    public event Action<GameObject> OnDeath;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 )
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath?.Invoke(gameObject);
        Destroy(gameObject);
    }
    
    
}

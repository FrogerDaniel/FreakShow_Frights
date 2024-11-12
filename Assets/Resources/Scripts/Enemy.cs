using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;  // Max health of the enemy
    private int currentHealth;   // Current health of the enemy

    public DamageBarMime damageBarMime;  // Reference to the DamageBarMime script (handles UI update)

    void Start()
    {
        currentHealth = maxHealth;  // Set current health to max health at the start

        // Update the damage bar UI when the enemy is spawned
        if (damageBarMime != null)
        {
            damageBarMime.UpdateDamage((float)currentHealth / maxHealth);
        }
    }

    // Method to handle when the enemy takes damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Update the damage bar UI
        if (damageBarMime != null)
        {
            damageBarMime.UpdateDamage((float)currentHealth / maxHealth);  // Update health fraction
        }

        // Check if the enemy's health reaches 0 or below and die
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method to handle the death of the enemy
    private void Die()
    {
        Debug.Log(gameObject.name + " has been killed!");

        // Optional: Play death animation or effects here before destroying the object
        Destroy(gameObject);  // Destroy the enemy object
    }
}

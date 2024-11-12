using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float health = 100f; // Starting health of the enemy
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float stoppingDistance = 1f;
    private Transform player;
    private Rigidbody rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = new Vector3(player.position.x - transform.position.x, 0, player.position.z - transform.position.z).normalized;

        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, direction.z * moveSpeed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        RotateTowardsPlayer(direction);
    }

    void RotateTowardsPlayer(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

    // Method to handle taking damage
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    // Method to handle the death of the enemy
    private void Die()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject); // Destroy the enemy object
    }
}

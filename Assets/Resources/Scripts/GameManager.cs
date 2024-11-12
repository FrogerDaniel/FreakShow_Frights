using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;  // Reference to enemy prefab
    [SerializeField] private Transform spawnPoint;    // Location to spawn enemies
    [SerializeField] private float spawnInterval = 5f;  // Interval between enemy spawns

    public float materialAmount = 0f;  // Amount of collected materials

    void Start()
    {
        materialAmount = 0f;
        Cursor.visible = true;
        StartCoroutine(SpawnEnemyRoutine());  // Start enemy spawn routine
    }

    void Update()
    {
        // You can add gameplay-related logic here
    }

    public void ChangeMaterialAmount()
    {
        materialAmount += 5;
        Debug.Log(materialAmount);
    }

    // Coroutine to spawn enemies at regular intervals
    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    // Spawn an enemy at the spawn point
    private void SpawnEnemy()
    {
        if (enemyPrefab != null && spawnPoint != null)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Enemy Spawned");
        }
        else
        {
            Debug.LogWarning("Enemy Prefab or Spawn Point is missing.");
        }
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //var for enemy
    [SerializeField]private GameObject enemyPrefab;
    //var for timers
    [SerializeField]private float minimumSpawnTime;
    [SerializeField]private float maximumSpawnTime;
    private float timeUntilSpawn;

    private void Awake()
    {
        //on awake initiate the random time
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        //make the timer count down
        timeUntilSpawn -= Time.deltaTime;

        if(timeUntilSpawn <= 0 )
        {
            //if timer reaches 0 or less, spawn an enemy and set a new timer
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        //set the time until spawn randomly between two numbers
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private float spawnInterval = 0.5f;
    private int maxEnemies = 20;
    public GameObject enemyPrefab;

    // public Wave[] waves;
    public int timeBetweenWaves = 5;
    private float lastSpawnTime;
    private int enemiesSpawned = 0;
    private GameManager gameManager;
    private int nextEnemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        nextEnemyHealth = 100;
    }

    private GameObject InstantiateEnemy(GameObject enemyPrefab) {
        GameObject newEnemy = (GameObject)Instantiate(enemyPrefab);
        Enemy enemy = newEnemy.GetComponent<Enemy>();
        enemy.MaxHealth = nextEnemyHealth;
        nextEnemyHealth += 20;
        return newEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnWave();
        // int currentWave = gameManager.Wave;
        // if (currentWave < waves.Length) {
        //     float timeInterval = Time.time - lastSpawnTime;
        //     float spawnInterval = waves[currentWave].spawnInterval;
        //     if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
        //     timeInterval > spawnInterval) && enemiesSpawned < waves[currentWave].maxEnemies) 
        //     {
        //         lastSpawnTime = Time.time;
        //         GameObject newEnemy = InstantiateEnemy(waves[currentWave].enemyPrefab);
        //         enemiesSpawned ++;
        //     }
            
        //     if (enemiesSpawned == waves[currentWave].maxEnemies &&
        //         GameObject.FindGameObjectWithTag("Enemy") == null) {
        //         gameManager.Wave ++;
        //         enemiesSpawned = 0;
        //         lastSpawnTime = Time.time;
        //     }
        // } else {
        //     // gameManager.gameOver = true;

        // }
    }

    void SpawnWave() {
            // 2
            float timeInterval = Time.time - lastSpawnTime;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                 timeInterval > spawnInterval) && enemiesSpawned < maxEnemies)
            {
                // 3  
                lastSpawnTime = Time.time;
                GameObject newEnemy = InstantiateEnemy(enemyPrefab);
                enemiesSpawned++;
            }
            // 4 
            if (enemiesSpawned == maxEnemies && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                gameManager.Wave++;
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
            // 5 
    }
}

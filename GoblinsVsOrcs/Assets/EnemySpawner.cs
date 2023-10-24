using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;
 
    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSec = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;
    [SerializeField] private float enemiesPerSecCap = 10f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private float eps;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void Awake() {
        onEnemyDestroy.AddListener(onEnemyDestroyed);
    }

    private void Start() {
        StartCoroutine(StartWave());
    }

    private void Update() {
        if(!isSpawning){
            return;
        }
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f / enemiesPerSec) && enemiesLeftToSpawn > 0) {
            SpawnEnemy();
            enemiesLeftToSpawn --;
            enemiesAlive ++;
            timeSinceLastSpawn = 0f;

        }
        
        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0){
            EndWave();
        }

    }

    private void onEnemyDestroyed(){
        enemiesAlive -- ;
    }

    private void EndWave(){
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        StartCoroutine(StartWave());
        currentWave++;
        LevelManager.main.totalReached ++;
    }

    private void SpawnEnemy(){
        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[index];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity );
    }

    private IEnumerator StartWave(){
        yield return new WaitForSeconds(timeBetweenWaves);
        
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
        eps = EnemiesPerSecond();

    }
    
    private int EnemiesPerWave(){
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
    private float EnemiesPerSecond(){
        return Mathf.Clamp((enemiesPerSec * Mathf.Pow(currentWave, difficultyScalingFactor)),0f ,enemiesPerSecCap);
    }
}


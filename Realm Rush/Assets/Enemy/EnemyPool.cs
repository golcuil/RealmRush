using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    
    [SerializeField] [Range(1,50)] int poolSize = 10;
    [SerializeField] [Range(0.1f,5f)] float spawnTimer = 1f;
    GameObject[] enemyPool;

    private void Awake()
    {
        enemyPool = new GameObject[poolSize];
        PopulatePool();
        
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void PopulatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemyInPool = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
            enemyPool[i] = enemyInPool;
            enemyPool[i].SetActive(false);
        }
    }

    void GetObjectInPool()
    {
        //GameObject enemyInPool = enemyPool[0];
        //enemyInPool.SetActive(true);

        foreach (var enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemies()
    {
        int counter = 0;
        while (counter < enemyPool.Length)
        {
            GetObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
            
        }
    }

}

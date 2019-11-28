using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnTimeMin, spawnTimeMax;

    private List<Transform> spawnPoints = new List<Transform>();
    private float spawnTime;
    private int enemyCount = 0;

    private void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            //Do not do this
            Vector3 enemyPos = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x + Random.Range(-10,10), 0.85f, GameObject.FindGameObjectWithTag("Player").transform.position.z + Random.Range(-10, 10));
            SpawnEnemy(enemyPos);
        }
    }

    //This should be pooled
    private void SpawnEnemy(Vector3 position)
    {
        enemyCount++;
        spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
        GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        enemy.GetComponent<EnemyController>().moveSpeed = (1 + enemyCount / 10);
    }
}

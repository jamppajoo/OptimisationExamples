using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float maxEnemyMoveSpeed;

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
        float moveSpeed = (1 + enemyCount / 10);
        if (moveSpeed >= maxEnemyMoveSpeed)
            moveSpeed = maxEnemyMoveSpeed;
        enemy.GetComponent<EnemyController>().moveSpeed = moveSpeed;

        enemy.GetComponent<Renderer>().material.color = Color.red;
        #region Coloring2.0
        //ColorEnemy(enemy);
        #endregion

    }
    #region Coloring2.0

    #endregion
    private void ColorEnemy(GameObject enemy)
    {
    MaterialPropertyBlock block = new MaterialPropertyBlock();
        enemy.GetComponent<Renderer>().GetPropertyBlock(block);
        block.SetColor("_Color", Color.red);
        enemy.GetComponent<Renderer>().SetPropertyBlock(block);

    }
}

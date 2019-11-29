using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float maxEnemyMoveSpeed;

    public float spawnTimeMin, spawnTimeMax;
    public bool spawnEnemies = true;

    private List<Transform> spawnPoints = new List<Transform>();
    private float spawnTime;
    private int enemyCount = 0;

    private void Update()
    {
        if (spawnEnemies)
        {
            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0)
            {
                //Do not do this

                //Spawns enemy to players x and z position added to random factor
                //Vector3 enemyPos = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x + Random.Range(-10, 10), 0.85f, GameObject.FindGameObjectWithTag("Player").transform.position.z + Random.Range(-10, 10));


                //SpawnEnemy(enemyPos);

                #region Spawning2.0
                SpawnEnemy(GetNewEnemyPos());
                #endregion
            }
        }
    }

    #region Spawning2.0

    private GameObject player;
    private Vector3 newPos;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private Vector3 GetNewEnemyPos()
    {
        newPos = player.transform.position;
        newPos.x += Random.Range(-10, 10);
        newPos.z += Random.Range(-10, 10);
        return newPos;
    }


    #endregion

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

        //enemy.GetComponent<Renderer>().material.color = Color.red;

        #region Coloring2.0
        ColorEnemy2(enemy);
        #endregion

    }
    #region Coloring2.0

    private void ColorEnemy2(GameObject enemy)
    {
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        enemy.GetComponent<Renderer>().GetPropertyBlock(block);
        block.SetColor("_Color", Color.red);
        enemy.GetComponent<Renderer>().SetPropertyBlock(block);

    }
    #endregion
}

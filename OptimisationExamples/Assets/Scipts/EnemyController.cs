using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1;
    public ScoreManager scoreManager;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        gameObject.transform.position =  Vector3.MoveTowards(gameObject.transform.position, player.transform.position,moveSpeed* Time.deltaTime);
    }

    private void Die()
    {
        Destroy(gameObject);
        //Because we instantiate enemys from prefab, we cant set scoreManager on Inspector
        scoreManager = GameObject.Find("ScoreManagerText").GetComponent<ScoreManager>();

        #region Kindof better way
        //ScoreManager.Instance.AddScore(10);
        #endregion

        scoreManager.AddScore(10);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.tag == "Bullet")
        {
            Die();
        }
    }

}


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
        //How to do this
        scoreManager = GameObject.Find("ScoreManagerText").GetComponent<ScoreManager>();
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


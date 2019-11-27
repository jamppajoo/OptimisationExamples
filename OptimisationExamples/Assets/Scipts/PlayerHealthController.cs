using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public Slider healthSlider;
    public LevelManager levelManager;
    private float maxHealth = 100;

    public float currentHealth = 100;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthSlider.value = currentHealth;
    }

    #region HealthReduce2.0
    private void Start()
    {
        healthSlider.value = currentHealth;   
    }

    private void ReduceHealth(float amountToReduce)
    {
        currentHealth -= amountToReduce;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
            levelManager.EndGame();
    }
    #endregion


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.tag == "Enemy")
        {
            currentHealth -= 1f;

          #region HealthReduce2.0
            //ReduceHealth(1);
            #endregion

        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text scoreText;
    private float score = 0;
    private void Awake()
    {
        scoreText = gameObject.GetComponent<Text>();
    }
    public void AddScore(float scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = "Score: " + score.ToString();
    }
}

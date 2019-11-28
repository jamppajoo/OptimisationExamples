using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;

    public static ScoreManager Instance { get { return _instance; } }


    private void Awake()
    {
        scoreText = gameObject.GetComponent<Text>();

        #region Improved by EnemyController
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        #endregion
    }
    private Text scoreText;
    private float score = 0;

    public void AddScore(float scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = "Score: " + score.ToString();
    }
}

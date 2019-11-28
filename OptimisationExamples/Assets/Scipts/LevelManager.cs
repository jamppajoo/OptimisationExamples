using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void EndGame()
    {
        Debug.Log("Nyyppä");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

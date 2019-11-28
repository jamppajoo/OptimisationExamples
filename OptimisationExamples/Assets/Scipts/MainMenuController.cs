using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
   public void ShowUI()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
    public void StartNewGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);

    }
}

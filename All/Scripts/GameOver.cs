using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class GameOver : MonoBehaviour
{
    

    public SceneFader sceneFader1;
    public string menuSceneName = "MainMenu";
    
    public void Retry()
    {
        sceneFader1.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader1.FadeTo(menuSceneName);
    }
}

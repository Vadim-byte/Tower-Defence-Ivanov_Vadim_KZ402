 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLevel : MonoBehaviour
{
    public string levelToLoad = "LevelSelect";
    public string levelToLoad2 = "TrainingLevel";

    public string BackLevel = "MainMenu";

    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }
    public void Training()
    {
        sceneFader.FadeTo(levelToLoad2);
    }

    public void Quit()
    {
        Debug.Log("Exicitng...");
        Application.Quit();
    }

    public void Back()
    {
        sceneFader.FadeTo(BackLevel);
    }

}

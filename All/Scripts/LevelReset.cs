using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReset : MonoBehaviour
{
    public SceneFader sceneFader;

    public string thisScene = "LevelSelect";
    
    public void ResetLevel()
    {

        PlayerPrefs.SetInt("levelReached", 1);
        sceneFader.FadeTo(thisScene);
    }

    public void OpenLevel()
    {

        PlayerPrefs.SetInt("levelReached", 10);
        sceneFader.FadeTo(thisScene);

    }

}

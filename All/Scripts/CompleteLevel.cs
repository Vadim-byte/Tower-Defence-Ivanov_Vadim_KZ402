using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public SceneFader sceneFader3;

    public void WinG()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }

    public void Continue()
    {
       
        sceneFader3.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader3.FadeTo(menuSceneName);
    }
}

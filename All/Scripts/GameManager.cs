using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class GameManager : MonoBehaviour
{
   public static bool GameIsOver;

    public GameObject gameOverUI;

    public GameObject completeLevelUI;

    public CompleteLevel completeLevel;

    private void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {
        if (GameIsOver)
        {
            return;
        }
        
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }


        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

    }

    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);

    }

    

    public void WinLevel()
    {

        
        GameIsOver = true;
        completeLevelUI.SetActive(true);
        completeLevel.WinG();

    }

}
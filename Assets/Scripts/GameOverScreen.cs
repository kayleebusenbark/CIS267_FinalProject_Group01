using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private GameManager gameManager;
    public Canvas gameOverCanvas;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        gameOverCanvas.enabled = false;
    }
    public void showGameOverScreen()
    {
        gameOverCanvas.enabled = true;
    }

    public void playAgain()
    {
        gameManager.replayGame();
        gameOverCanvas.enabled = false;
    }

    public void exitGame()
    {
        gameManager.exitGame();
    }

    public void showArtCreditScreen()
    {
        gameManager.showArtCreditScreen();
    }


    public void showControlerScreen()
    {
        gameManager.showControlerScreen();
    }



}

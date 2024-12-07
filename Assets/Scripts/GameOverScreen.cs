using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private GameManager gameManager;
    public Canvas gameOverCanvas;
    public GameObject defaultButton;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        gameOverCanvas.enabled = false;

        EventSystem.current.SetSelectedGameObject(null);
    }

    void Update()
    {
        if(gameOverCanvas.enabled && Input.GetButtonDown("Cancel"))
        {
            closeScreens();
        }
    }
    public void showGameOverScreen()
    {
        gameOverCanvas.enabled = true;

        EventSystem.current.SetSelectedGameObject(defaultButton);
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

    public void closeScreens()
    {
        gameManager.hideArtCreditScreen();
        gameManager.hideControlerScreen();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultButton);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public Canvas pauseMenuCanvas;
    private bool isPaused = false;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuCanvas.enabled = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            pauseGame();
        }
    }

    public void pauseGame()
    {
        pauseMenuCanvas.enabled=true;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.enabled = false;
        Time.timeScale = 1f;
        isPaused = false;   
    }

    public void showArtCreditScreen()
    {
        gameManager.showArtCreditScreen();
    }

    public void hideArtCreditScreen()
    {
        gameManager.hideArtCreditScreen();
    }

    public void showControlerScreen()
    {
        gameManager.showControlerScreen();
    }

    public void hideControlerScreen()
    {
        gameManager.hideControlerScreen();
    }

    public void quitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }
}

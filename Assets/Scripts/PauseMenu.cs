using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public Canvas pauseMenuCanvas;
    public Canvas gameOverCanvas;
    private bool isPaused = false;
    private GameManager gameManager;
    public GameObject defaultButton;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuCanvas.enabled = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameOverCanvas.enabled) return;

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            pauseGame();
        }

        if(isPaused && Input.GetButtonDown("Cancel"))
        {
            closeScreens();
        }
    }

    public void pauseGame()
    {
        pauseMenuCanvas.enabled=true;
        Time.timeScale = 0f;
        isPaused = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultButton);
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.enabled = false;
        EventSystem.current.SetSelectedGameObject(null);
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

        gameManager.loadStartScreen();
        pauseMenuCanvas.enabled = false ;
    }

    public void closeScreens()
    {
        gameManager.hideArtCreditScreen();
        gameManager.hideControlerScreen();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultButton);
    }
}

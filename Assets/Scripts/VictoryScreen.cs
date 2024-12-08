using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VictoryScreen : MonoBehaviour
{
    private GameManager gameManager;
    public Canvas victoryCanvas;
    public GameObject defaultButton;
    public float delayBeforeShowing = 2f;
    private LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        victoryCanvas.enabled = false;
        EventSystem.current.SetSelectedGameObject(null);
    }

    // Update is called once per frame
    void Update()
    {
        if(victoryCanvas.enabled && Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            return;
        }
    }

    public void triggerVictoryScreen()
    {
        StartCoroutine(showVictoryScreenWithDelay());
    }

    private IEnumerator showVictoryScreenWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeShowing);

        victoryCanvas.enabled = true;

        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultButton);
    }

    public void playAgain()
    {
        gameManager.replayGame();
        victoryCanvas.enabled = false;

    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        gameManager.loadStartScreen();
        victoryCanvas.enabled = false;
    }
}

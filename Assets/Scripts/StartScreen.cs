using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

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

    public void startGame()
    {
        gameManager.startGame();
    }

    public void exitGame()
    {
        gameManager.exitGame();
    }
}

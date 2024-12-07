using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartScreen : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject defaultButton;

    //public GameObject controlsScreen;
    //public GameObject creditsScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultButton);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            closeScreens();
        }
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

    public void closeScreens()
    {
        gameManager.hideArtCreditScreen();
        gameManager.hideControlerScreen();  
        EventSystem.current.SetSelectedGameObject(defaultButton);
    }

}

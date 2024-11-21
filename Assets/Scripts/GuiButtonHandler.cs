using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private GameManager gameManager;
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    public void playGame()
    {
        gameManager.startGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private GameManager gameManager;
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void playGame()
    {
        gameManager.startGame();    
    }
}

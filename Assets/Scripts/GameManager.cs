using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
       levelLoader = FindObjectOfType<LevelLoader>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        levelLoader.loadNextLevel();
    }
}

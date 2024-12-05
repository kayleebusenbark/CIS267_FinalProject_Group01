using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private LevelLoader levelLoader;
    public Canvas ArtCreditsScreen;
    public Canvas ControlerScreen;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

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

    public void showArtCreditScreen()
    {
        ArtCreditsScreen.enabled = true;
    }

    public void hideArtCreditScreen()
    {
        ArtCreditsScreen.enabled=false;
    }

    public void showControlerScreen()
    {
        ControlerScreen.enabled = true;
    }

    public void hideControlerScreen()
    {
        ControlerScreen.enabled=false;  
    }



}

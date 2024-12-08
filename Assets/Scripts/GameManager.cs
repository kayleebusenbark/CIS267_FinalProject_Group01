using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private LevelLoader levelLoader;
    public Canvas ArtCreditsScreen;
    public Canvas ControlerScreen;
    private MusicManager musicManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        musicManager = GetComponent<MusicManager>();

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
        ArtCreditsScreen.enabled = false;
    }

    public void showControlerScreen()
    {
        ControlerScreen.enabled = true;
    }

    public void hideControlerScreen()
    {
        ControlerScreen.enabled = false;
    }

    public void loadStartScreen()
    {
        Time.timeScale = 1.0f;
        NoDestroyLevel levelInstance = FindObjectOfType<NoDestroyLevel>();

        if (levelInstance != null)
        {
            Destroy(levelInstance.gameObject);
        }

        SceneManager.LoadScene("StartScreen");
    }

    public void replayGame()
    {
        Time.timeScale = 1.0f;
        NoDestroyLevel levelInstance = FindObjectOfType<NoDestroyLevel>();

        if (levelInstance != null)
        {
            Destroy(levelInstance.gameObject);
        }
        StartCoroutine(levelLoader.loadLevel(2));
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void toggleMusic()
    {
        musicManager.toggleMusic();
    }

    public void handleSceneMusic(AudioSource sceneMusic)
    {
        musicManager.setCurrentMusic(sceneMusic);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusicSetUp : MonoBehaviour
{
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.handleSceneMusic(music);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transitionAnimation;
    public float transitionTime;

    private Level03EnemySpawner level03EnemySpawner;
    private PickUpSpawner pickUpSpawner;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void loadNextLevel()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator loadLevel(int levelIndex)
    {
        transitionAnimation.SetTrigger("End");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

        transitionAnimation.SetTrigger("Start");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level01")
        {
            level03EnemySpawner = FindObjectOfType<Level03EnemySpawner>();
            pickUpSpawner = FindObjectOfType<PickUpSpawner>();

            if (level03EnemySpawner != null)
            {
                level03EnemySpawner.spawnEnemies();
                pickUpSpawner.spawnPickUps();
            }
            else
            {
                Debug.LogWarning("LEVEL 03 ENEMY SPAWNER NOT FOUND");
            }

        }
        if (scene.name == "Level03")
        {
            level03EnemySpawner = FindObjectOfType<Level03EnemySpawner>();

            if (level03EnemySpawner != null)
            {
                level03EnemySpawner.spawnEnemies();
            }
            else
            {
                Debug.LogWarning("LEVEL 03 ENEMY SPAWNER NOT FOUND");
            }

        }
    }
}

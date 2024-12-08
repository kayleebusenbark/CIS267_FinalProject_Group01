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
    public GameObject levelNoDestroyPrefab;

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

    public IEnumerator loadLevel(int levelIndex)
    {
        transitionAnimation.SetTrigger("End");

        yield return new WaitForSeconds(transitionTime);

        if (levelIndex == 2 && FindObjectOfType<NoDestroyLevel>() == null)
        {
            Instantiate(levelNoDestroyPrefab);
        }

        SceneManager.LoadScene(levelIndex);

        transitionAnimation.SetTrigger("Start");

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level01" || scene.name == "Level02" || scene.name == "Level03")
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

    }
}

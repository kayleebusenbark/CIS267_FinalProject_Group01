using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03EnemySpawner : MonoBehaviour
{

    public GameObject[] spawnedObjects;
    public List<GameObject> spawnLocations = new List<GameObject>();
    private Level03EnemyFollow enemyFollow;


    public void spawnEnemies()
    {
        foreach (GameObject spawnLocation in spawnLocations)
        {
            int randomEnemy = Random.Range(0, spawnedObjects.Length);

            GameObject spawnEnemy = Instantiate(spawnedObjects[randomEnemy], spawnLocation.transform.position, Quaternion.identity);

            enemyFollow = spawnEnemy.GetComponent<Level03EnemyFollow>();
            enemyFollow.setOriginalPosition(spawnLocation.transform.position);
        }

    }

}

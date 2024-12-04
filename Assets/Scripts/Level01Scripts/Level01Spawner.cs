using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class Level01Spawner : MonoBehaviour
{
    //[SerializeField]
    //private GameObject[] spawnedEnemies;
    //[SerializeField]
    //private List<GameObject> spawnedLocation = new List<GameObject>();
    //private Level01Enemy enemy;

    //public void SpawnEnemies()
    //{
    //    if (spawnedEnemies.Length == 0 || spawnedLocation.Count == 0)
    //    {
    //        Debug.Log("No enemy spawns");
    //        return;
    //    }

    //    foreach (GameObject spawnedLocations in spawnedLocation)
    //    {
    //        int randEnemyIndex = Random.Range(0, spawnedEnemies.Length);

    //        GameObject spawnEnemy = Instantiate(spawnedEnemies[randEnemyIndex], spawnedLocations.transform.position,Quaternion.identity);

    //        enemy = spawnEnemy.GetComponent<Level01Enemy>();

    //        if (enemy != null)
    //        {
    //            enemy.SetOriginalPos(spawnedLocations.transform.position);
    //        }
    //        else
    //        {
    //            Debug.Log("Spawned enemy doesnt have the follower");
    //        }
    //    }
    //}


    public GameObject[] enemySpawnLocations = new GameObject[12];
    public GameObject[] enemyType = new GameObject[3];

    void Start()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        for (int i = 0; i < enemySpawnLocations.Length; i++)
        {
            int randomNum = Random.Range(0, enemyType.Length);

            GameObject enemyToSpawn = Instantiate(enemyType[randomNum]);
            enemyToSpawn.transform.position = new Vector2(enemySpawnLocations[i].transform.position.x, enemySpawnLocations[i].transform.position.y);
        }
    }


}

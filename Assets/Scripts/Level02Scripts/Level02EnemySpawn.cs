using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level02EnemySpawn : MonoBehaviour
{
    public GameObject[] enemySpawnLocations = new GameObject[21];
    public GameObject[] enemyType = new GameObject[2];

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

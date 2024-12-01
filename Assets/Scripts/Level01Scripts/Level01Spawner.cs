using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level01Spawner : MonoBehaviour
{
    public GameObject spawnedEnemies;
    public float spawnTime;
    public float coolDown = 1f; 

    //to control the time/ speed of enemies spawning 
    //public float time; 
    //public float timeDelay;

    //the gameObjects are will be where the enemeies spawn 
    public GameObject[] spawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }

       // time += Time.deltaTime;
        if (spawnTime <= 0)
        {
            spawnEnemy();
            spawnTime = coolDown; 
        }
    }

    private void spawnEnemy()
    {
        int spawnNum = Random.Range(0, spawnLocations.Length);
        
        GameObject spawnLocation = spawnLocations[spawnNum];

        Instantiate(spawnedEnemies); 
        spawnedEnemies.transform.position = new Vector2(spawnLocation.transform.position.x, spawnLocation.transform.position.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01Spawner : MonoBehaviour
{
    public GameObject spawnedEnemies;

    //to control the time/ speed of enemies spawning 
    public float time; 
    public float timeDelay;

    //the gameObjects are will be where the enemeies spawn 
    public GameObject[] spawnLocations; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;


        if (time >= timeDelay)
        {
            spawnEnemy();
            time = 0f; 
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

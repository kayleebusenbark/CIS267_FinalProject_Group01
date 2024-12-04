using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01BerrySpawner : MonoBehaviour
{
    public GameObject spawnedObject;
    public List<GameObject> spawnLocations = new List<GameObject>();

    // Start is called before the first frame update
    public void spawnBerries()
    {
        foreach (GameObject spawnLocation in spawnLocations)
        {

            GameObject spawnEnemy = Instantiate(spawnedObject,spawnLocation.transform.position, Quaternion.identity);

        }

    }
}

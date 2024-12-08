using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner: MonoBehaviour
{
    public GameObject spawnedObject;
    public List<GameObject> spawnLocations = new List<GameObject>();

    // Start is called before the first frame update
    public void spawnPickUps()
    {
        foreach (GameObject spawnLocation in spawnLocations)
        {

            GameObject pickUp = Instantiate(spawnedObject,spawnLocation.transform.position, Quaternion.identity);

        }

    }
}

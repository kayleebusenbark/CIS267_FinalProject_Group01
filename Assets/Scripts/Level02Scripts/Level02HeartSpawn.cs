using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Level02HeartSpawn : MonoBehaviour
{
    public GameObject[] heartSpawnLocations = new GameObject[8];
    public GameObject[] healthPickupType = new GameObject[1];
    // Start is called before the first frame update
    void Start()
    {
        HeartSpawn();
    }

    private void HeartSpawn()
    {
        for (int i = 0; i < heartSpawnLocations.Length; i++)
        {
            int randomNum = Random.Range(0, healthPickupType.Length);

            GameObject healthToSpawn = Instantiate(healthPickupType[randomNum]);
            healthToSpawn.transform.position = new Vector2(heartSpawnLocations[i].transform.position.x, heartSpawnLocations[i].transform.position.y);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02Enemies : MonoBehaviour
{
    private GameObject player;

    private GameObject gameManager;

    private Vector2 playerSpot;

    public float speed;

    public float enemyHealth;

    public int enemyValue;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        playerSpot = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerSpot,speed * Time.deltaTime);
    }
}

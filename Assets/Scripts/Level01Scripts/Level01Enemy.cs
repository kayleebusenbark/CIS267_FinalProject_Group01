using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01Enemy : MonoBehaviour
{
    private GameObject player;
    private GameObject gameManager; 
    private Vector2 playerLocation;
    private float speed; 
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 

        

    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision " + collision.gameObject.name);

        if(collision)
        {

        }
        else
        {
            isDead(); 
        }
    }

    private void isDead()
    {

    }

    //private void enemyAttack()
    //{
    //    if()
    //    {

    //    }
    //    else
    //    {
    //        enemyIdle();
    //    }
    //}

    //private void enemyIdle()
    //{
    //    if()
    //    {

    //    }
    //    else
    //    {
    //        isDead(); 
    //    }

    //}

    //private void enemyWalk()
    //{
    //    if()
    //    {

    //    }
    //    else
    //    {
    //        enemyIdle();
    //    }
    //}
}

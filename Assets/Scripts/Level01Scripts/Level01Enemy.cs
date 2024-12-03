using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01Enemy : MonoBehaviour
{
    PlayerHealth playerHealth;
    private PlayerController player; 
    private Animator myAnimator;
    private Vector2 originalPos;
    public float speed;
    public float distanceBetween;
    public SpriteRenderer spriteRenderer;
    public int attackPower = 10; 

   
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        myAnimator = GetComponent<Animator>();
        //initizalze at the start so that we can avoid errors; 
        originalPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // playerLocation = player.transform.position;
        // transform.position = Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime);

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction;

        if (distanceToPlayer < distanceBetween)
        {
            myAnimator.SetBool("playerDetected", true);
            direction = player.transform.position - transform.position;
            direction.Normalize();

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        }
        else
        {
            direction = originalPos - (Vector2)transform.position;

            if(direction.magnitude > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, originalPos, speed * Time.deltaTime);
            }
            else
            {
                myAnimator.SetBool("playerDetected", false);
            }
        }

        FlipEnemySprite(direction);

    }

    public void SetOriginalPos(Vector2 pos)
    {
        originalPos = pos;
    }

    private void FlipEnemySprite(Vector2 direction)
    {
       if(CompareTag("BushMonster") || CompareTag("FlowerEnemy") || CompareTag("Orc"))
        {
            spriteRenderer.flipX = direction.x > 0; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision " + collision.gameObject.name);

        if(collision.CompareTag("PlayerHitBox"))
        {
            PlayerHealth playerHealth = collision.GetComponentInParent<PlayerHealth>();
            playerHealth.takeDamage(attackPower);

        }
      
    }

    private void isDead()
    {
        myAnimator.SetBool("death", true);
        myAnimator.SetBool("boom", true);
        Destroy(myAnimator);
    }

    private void enemyAttack()
    {
        myAnimator.SetBool("attack", true);
       
    }



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

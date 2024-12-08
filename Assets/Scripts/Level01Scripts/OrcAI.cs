using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrcAi : MonoBehaviour
{
    private Transform player;
    public int attackDamage = 10;
    public float attackRange = 5f;
    public float attackCoolDown = 1f;
    private float lastAttackTime;
    public float speed;
    private Animator myAnimator;
    //private Transform target;
    private bool isAttacking = false;
    private bool isDead = false;
    private bool isActive = false;
    [SerializeField]
    private float minRange;
    [SerializeField]
    private float maxRange;
    public int health = 10;
    public float orcSpeed = 1f;
    public float distance = .4f; 
    




    // Start is called before the first frame update
    void Start()
    {
        enabled = false;

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive || isDead || player == null)
        {
            //don't do anyhting if the orc is dead 
            return; 
        }


        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCoolDown)
        {
            attackPlayer(); 
        }
        else if(!isAttacking && distanceToPlayer <= maxRange && distanceToPlayer > minRange)
        {
            MoveToPlayer();
        }
        else
        {
            StopMoving();
        }

        FacePlayer();
        
    }

    private void FacePlayer()
    {
        if(player != null)
        {
            Vector3 direction =(player.position - transform.position).normalized;
            if(direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    private void StopMoving()
    {
       myAnimator.SetBool("isMoving", false);
       myAnimator.SetBool("playerDetected", false);
    }

    private void MoveToPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if(distanceToPlayer > distance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * orcSpeed * Time.deltaTime;

            myAnimator.SetBool("isMoving", true);
        }
        else
        {
            myAnimator.SetBool("isMoving", false);
            attackPlayer(); 
        }
       
        
    }

    public void attackPlayer()
    {
        isAttacking = true;
        myAnimator.SetTrigger("attack"); 
        lastAttackTime = Time.time;

       //s Invoke(nameof(TakeDamage), 0, 5f);
        

    }
    public void activateOrc()
    {
        enabled = true;
        isActive = true;
    }


    private void DealDamage()
    {
        if(player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.takeDamage(attackDamage);
            }
        }

        isAttacking= false;
    }

    private void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }

        health -= damage; 

        if(health <= 0)
        {
            Death(); 
        }
        else
        {
            myAnimator.SetTrigger("hit"); 
        }
    }

    private void Death()
    {
        isDead = true;

        myAnimator.SetTrigger("Death"); 

        StopMoving();

        GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision " + collision.gameObject.name);

        if (collision.CompareTag("PlayerHitBox"))
        {
            myAnimator.SetBool("playerDetected", true); 
            PlayerHealth playerHealth = collision.GetComponentInParent<PlayerHealth>();

            if(playerHealth != null)
            {
                playerHealth.takeDamage(attackDamage);
            }
        }
        
    }

    //private void isDead()
    //{
    //    myAnimator.SetBool("death", true);
    //    Destroy(myAnimator);
    //}


}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrcAi : MonoBehaviour
{
    public Transform player;
    public int attackDamage = 10; 
    public float attackRange = 5f;
    public float attackCoolDown = 1f;
    private float lastAttackTime;
    public float speed;
    private Animator myAnimator;
    private Transform target;
    private bool isAttacking = false;
    [SerializeField]
    private float minRange;
    [SerializeField]
    private float maxRange;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        myAnimator = GetComponent<Animator>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < attackRange)
        {
            attackPlayer(); 
        }

        if(!isAttacking)
        {
            MoveToPlayer();
        }
        
    }

    private void MoveToPlayer()
    {
       
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void attackPlayer()
    {
        if (Time.time >= lastAttackTime + attackCoolDown)
        {
            player.GetComponent<PlayerHealth>().takeDamage(attackDamage); 
            lastAttackTime = Time.time;

            myAnimator.SetBool("attack", true); 
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision " + collision.gameObject.name);

        if (collision.CompareTag("PlayerHitBox"))
        {
            PlayerHealth playerHealth = collision.GetComponentInParent<PlayerHealth>();
            playerHealth.takeDamage(attackDamage);

        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            myAnimator.SetBool("isMoving", false);
        }
    }

    private void isDead()
    {
        myAnimator.SetBool("death", true);
        Destroy(myAnimator);
    }


}

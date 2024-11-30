using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemy : MonoBehaviour
{

    public Animator animator;
    private Level03EnemyHealth enemyHealth;
    private Transform player;
    public float attackDistance = 0.5f;
    private bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<Level03EnemyHealth>();
        player = FindObjectOfType<PlayerController>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position); 

        if(distanceToPlayer < attackDistance)
        {
            animator.SetBool("isWalking", false);
            animator.SetTrigger("attack");
        }
    }
}

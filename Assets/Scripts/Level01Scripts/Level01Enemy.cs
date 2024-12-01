using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01Enemy : MonoBehaviour
{
    private GameObject player;
    private GameObject gameManager;
    private Vector2 moveLocation;
    private float timer;
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float minRange; 
    [SerializeField]
    private float maxRange; 
    public Transform target; 
    public Rigidbody2D rb;
    public int attackPower = 10; 

    public Transform homePos; 
    private Animator myAnimator; 
   
    
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player"); 
        myAnimator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform; 

    }

    // Update is called once per frame
    void Update()
    {
       // playerLocation = player.transform.position;
       // transform.position = Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime);

        if(Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            followPlayer();
        }
        else
        {
            goHome();
        }
        
        
    }


    public void followPlayer()
    {
        myAnimator.SetBool("isMoving", true);
        myAnimator.SetFloat("moveX", target.position.x - transform.position.x);
        myAnimator.SetFloat("moveY", target.position.y - transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime); 
    }

    public void goHome()
    {
        myAnimator.SetFloat("moveX", homePos.position.x - transform.position.x);
        myAnimator.SetFloat("moveY", homePos.position.y - transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, homePos.position) == 0 )
        {
            myAnimator.SetBool("isMoving", false); 
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
        else if(Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            myAnimator.SetBool("isMoving", false);
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

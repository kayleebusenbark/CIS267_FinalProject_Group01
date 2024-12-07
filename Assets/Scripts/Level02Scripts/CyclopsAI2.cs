using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopsAI2 : MonoBehaviour
{

    public float moveSpeed = 0.75f;
    public float stopDistance = 1f;
    public float chargeTime = 5f;
    public float laserDuration = 5f;
    public float cooldownTime = 3f;
    public Transform laserSpawnPoint;
    public GameObject laserPrefab;
    public Animator animator;

    private Transform player;
    private bool isAttacking = false;
    private bool isDead = false;
    private bool facingRight = true;
    private Vector2 lastPlayerPosition;
    private float currentCooldown = 0f;
    private SpriteRenderer spriteRenderer;

    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        //if (playerObject != null)
        //{
        //    player = playerObject.transform;
        //}

        //animator = GetComponent<Animator>();
        //enabled = false;

        //spriteRenderer =  GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (!isAttacking)
        {
            if (distanceToPlayer > stopDistance)
            {
                MoveTowardsPlayer();
            }
            else
            {
                lastPlayerPosition = player.position;

                if (currentCooldown <= 0)
                {
                    StartCoroutine(LaserAttack());
                    currentCooldown = cooldownTime;

                }
            }
        }

        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

        animator.SetBool("isWalking", true);

        if ((direction.x > 0 && !facingRight) || (direction.x < 0 && facingRight))
        {
            flip();
        }
    }

    private IEnumerator LaserAttack()
    {
        isAttacking = true;

        animator.SetTrigger("laser");


        yield return new WaitForSeconds(chargeTime);

        source.PlayOneShot(clip);

        if (laserSpawnPoint != null)
        {
            GameObject laser = Instantiate(laserPrefab, laserSpawnPoint.position, Quaternion.identity);
            Laser2 laserScript = laser.GetComponent<Laser2>();
            laserScript.setMoveDirection(lastPlayerPosition);
        }

        isAttacking = false;
    }

    //public void activateCyclops()
    //{
    //    enabled = true;
    //}

    private void flip()
    {
        facingRight = !facingRight; 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;   
    }
}

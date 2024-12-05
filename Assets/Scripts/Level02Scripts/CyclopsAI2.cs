using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopsAI2 : MonoBehaviour
{

    public float moveSpeed = 0.75f;
    public float stopDistance = 1f;
    public float chargeTime = 2f;
    public float laserDuration = 1f;
    public Transform eyePivot;
    public GameObject laserPrefab;
    public Animator animator;

    private Transform player;
    private bool isAttacking = false;
    private bool isDead = false;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (!isAttacking)
        {
            if (distanceToPlayer > stopDistance)
            {
                MoveTowardsPlayer();
            }
            else
            {
                StartCoroutine(LaserAttack());
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

        if((direction.x > 0 && !facingRight ) || (direction.x <0 && facingRight))
        {
            flip();
        }
    }

    private IEnumerator LaserAttack()
    {
        isAttacking = true;

        animator.SetTrigger("laser");

        yield return new WaitForSeconds(chargeTime);

        GameObject laser = Instantiate(laserPrefab, eyePivot.position, eyePivot.rotation);
        laser.transform.SetParent(eyePivot);

        yield return new WaitForSeconds(laserDuration);

        Destroy(laser);

        isAttacking = false;
    }

    private void flip()
    {
        facingRight = !facingRight; 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;   
    }
}

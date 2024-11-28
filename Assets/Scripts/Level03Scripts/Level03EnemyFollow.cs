using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03EnemyFollow : MonoBehaviour
{
    private PlayerController player;
    public float speed;
    private float distance;
    public SpriteRenderer spriteRenderer;
    public float distanceBetween;
    Animator animator;

    private Vector2 orginalPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction;

        if (distance < distanceBetween)
        {
            animator.SetBool("playerDetected", true);
            direction = player.transform.position - transform.position;
            direction.Normalize();

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position , speed * Time.deltaTime);
        }
        else
        {

            direction = orginalPosition - (Vector2)transform.position;

            if(direction.magnitude > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, orginalPosition, speed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("playerDetected", false);
            }

        }
        handleSpriteFlips(direction);
    }

    public void setOriginalPosition(Vector2 position)
    {
        orginalPosition = position;
    }

    private void handleSpriteFlips(Vector2 direction)
    {
        if (tag.Equals("WolfEnemy") && direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (tag.Equals("WolfEnemy") && direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (tag.Equals("SkeletonEnemy") && direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (tag.Equals("SkeletonEnemy") && direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02EnemyFollow : MonoBehaviour
{
    private PlayerController player;
    public float enemySpeed;
    private float distance;
    public SpriteRenderer spriteRenderer;
    public float distanceBetweenPlayer;
    Animator animator;

    private Vector2 originalPosition;

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

        if (distance < distanceBetweenPlayer)
        {
            animator.SetBool("playerDetected", true);
            direction = player.transform.position - transform.position;
            direction.Normalize();

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        }
        else
        {
            direction = originalPosition - (Vector2)transform.position;

            if (direction.magnitude > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, originalPosition, enemySpeed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("playerDetected,", false);
            }
        }
        flipEnemySprites(direction);
    }
    public void setOriginalPosition (Vector2 position)
    {
        originalPosition = position;
    }
    private void flipEnemySprites (Vector2 direction)
    {
        if (tag.Equals("BatEnemy") && direction.x > 0)
        {
            spriteRenderer.flipX= true;
        }
        else if (tag.Equals("BatEnemy") && direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (tag.Equals("SpiderEnemy") && direction.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (tag.Equals("SpiderEnemy") && direction.x < 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03EnemyHealth : MonoBehaviour
{
    public float health = 3;
    public float maxHealth = 3;
    private float currentHealth;
    public float destroyDelay = 0.5f;
    public float pushbackForce = 1f;


    private Animator animator;

    private Rigidbody2D rb;
    private PlayerController player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        currentHealth = maxHealth;

    }

    public void takeDamage(float damage)
    {
        health -= damage;
        currentHealth -= damage;

        animator.SetTrigger("hit");
        
        pushBackFromPlayer();

        if (currentHealth <= 0)
        {
            defeated();
        }
    }

    private void pushBackFromPlayer()
    {
        Vector2 pushDirection = (Vector2)(transform.position - player.transform.position).normalized;

        rb.AddForce(pushDirection * pushbackForce, ForceMode2D.Impulse);
    }


    public void defeated()
    {
        animator.SetTrigger("death");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        Destroy(gameObject, destroyDelay);
    }
}

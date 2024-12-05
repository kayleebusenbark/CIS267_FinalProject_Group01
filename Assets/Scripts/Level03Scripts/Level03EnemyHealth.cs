using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03EnemyHealth : MonoBehaviour
{
    public float health = 3;
    public float maxHealth = 3;
    private float currentHealth;
    public float destroyDelay = 0.5f;
    public float pushbackForce = 0.1f;


    private Animator animator;

    private Rigidbody2D rb;
    private PlayerController player;

    public GameObject heartPrefab;
    public GameObject gem;

    // (0 = never and 1 = always) 
    [Range(0f,1f)] public float heartDropChange = 0.3f;

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


        //this is so the wizard doesn't get pushed back since he's not really following the player as much as the other enemies
        if(GetComponent<WizardAI>() == null)
        {
            pushBackFromPlayer();

        }

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

        if(gem != null)
        {
            Instantiate(gem, transform.position, Quaternion.identity);

        }

        if (heartPrefab != null && Random.value <= heartDropChange)
        {
            Instantiate(heartPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject, destroyDelay);

    }
}

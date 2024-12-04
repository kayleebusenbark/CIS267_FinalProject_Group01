using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01EnemyHealth : MonoBehaviour
{
    public float health = 3;
    public float maxHealth = 3;
    public float destroyDelay = 0.5f;
    public float pushbackForce = 0.1f;
    public GameObject emeraldPrefab;
    public GameObject heartPrefab;
    private float curHealth;
    private Animator myAnimator;
    private Rigidbody2D rb;
    private PlayerController player;

    [Range(0f, 1f)] public float heartDrop = 0.3f; 
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<PlayerController>();

        curHealth = maxHealth;
        
    }

    public void death()
    {
        myAnimator.SetTrigger("death");
        myAnimator.SetTrigger("boom"); 

        GetComponent<Collider2D>().enabled = false;

        this.enabled = false;

        if (heartPrefab != null && Random.value <= heartDrop)
        {
            Instantiate(heartPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject, destroyDelay);

        Instantiate(emeraldPrefab, transform.position, Quaternion.identity);
    }

}

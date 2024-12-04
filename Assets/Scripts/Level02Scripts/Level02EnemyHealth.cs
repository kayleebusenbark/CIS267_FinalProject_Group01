using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 3;
    public float maxHealth = 3;
    public float destroyDelay = 0.5f;
    public float pushbackForce = 0.1f;

    private float currentHealth;

    private Animator animator;
    private PlayerController player;
    private Rigidbody2D rb;

    public GameObject sapphirePrefab;
    public GameObject heartPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

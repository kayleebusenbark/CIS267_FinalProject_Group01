using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currHealth;

    public HealthBar healthBar;
    private Animator playerAnimator;
    private bool isDead = false;

    private float damageCoolDown = 0.4f;
    private float lastDamageTime;

    private SpriteRenderer spriteRenderer;
    public Color originalColor;
    public Color damageColor = Color.red;
    public float flashDuration = 0.2f;

    private GameOverScreen gameOverCanvas;

    private bool isInvincible = false;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerAnimator = GetComponent<Animator>();
        gameOverCanvas = FindObjectOfType<GameOverScreen>();    

        spriteRenderer = GetComponentInParent<SpriteRenderer>();

        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void takeDamage(int damage)
    {
        if(isDead || isInvincible || Time.time - lastDamageTime < damageCoolDown)
        {
            return;
        }

        lastDamageTime = Time.time;

        currHealth -= damage;
        healthBar.SetHealth(currHealth);

        //damage animation isnt working and i dont feel like dealing with it anymore sooooo imma make my own "Animation"
        //playerAnimator.SetTrigger("damage");
        StartCoroutine(flashRed());


        if (currHealth <= 0)
        {
            die();
        }
    }

    private void die()
    {
        isDead = true;

        //playerAnimator.SetTrigger("die");

        //GetComponent<PlayerController>().enabled = false;

        gameOverCanvas.showGameOverScreen();

        Time.timeScale = 0f;
    }

    private IEnumerator flashRed()
    {
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    public void setInvincible(bool state)
    {
        isInvincible = state;

        if(state)
        {
            spriteRenderer.color = Color.yellow;
        }

        else
        {
            spriteRenderer.color = originalColor;
        }
    }
}

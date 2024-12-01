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

    private float damageCoolDown = 0.6f;
    private float lastDamageTime;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void takeDamage(int damage)
    {
        //if(isDead || !GetComponent<PlayerInvincibility>().canTakeDamage()) return;

        if(Time.time - lastDamageTime < damageCoolDown)
        {
            return;
        }

        lastDamageTime = Time.time;

        currHealth -= damage;
        healthBar.SetHealth(currHealth);

        playerAnimator.SetTrigger("damage");


        if (currHealth <= 0)
        {
            die();
        }
    }

    private void die()
    {
        isDead = true;

        playerAnimator.SetTrigger("die");

        GetComponent<PlayerController>().enabled = false;
    }


}

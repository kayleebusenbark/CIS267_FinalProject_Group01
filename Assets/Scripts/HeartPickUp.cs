using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickUp : MonoBehaviour
{
    public int healthRestoreAmount = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

        if (playerHealth.currHealth < playerHealth.maxHealth)
        {
            playerHealth.currHealth += healthRestoreAmount;

            if (playerHealth.currHealth > playerHealth.maxHealth)
            {
                playerHealth.currHealth = playerHealth.maxHealth;
            }

            playerHealth.healthBar.SetHealth(playerHealth.currHealth);

            Destroy(gameObject);

        }
    }
}
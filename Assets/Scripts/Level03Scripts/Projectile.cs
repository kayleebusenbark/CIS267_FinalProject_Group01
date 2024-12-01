using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerHitBox"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            playerHealth.takeDamage(damage);
            Destroy(gameObject);
        }

        else if(collision.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03EnemyHealth : MonoBehaviour
{
    public float health = 3;

    public void takeDamage(float damage)
    {
        health -= damage;

        if(health <= 0 )
        {
            defeated();
        }
    }


    public void defeated()
    {
        Destroy(gameObject);
    }
}

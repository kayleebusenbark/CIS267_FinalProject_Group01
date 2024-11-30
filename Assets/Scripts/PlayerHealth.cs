using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void takeDamage(int damage)
    {
        currHealth =- damage;
        healthBar.SetHealth(currHealth);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack01 : MonoBehaviour
{

    public Collider2D swordColliderAttack01;
    private Vector2 rightAttack1Offset;

    private Level03EnemyHealth enemyHealth;

    public float damage = 1;

    private void Start()
    {
        rightAttack1Offset = transform.localPosition;
    }


    public void attackRight()
    {
        print("Attack Right");
        swordColliderAttack01.enabled = true;
        transform.localPosition = rightAttack1Offset;
    }

    public void attackLeft()
    {
        print("Attack Left");
        swordColliderAttack01.enabled = true;
        transform.localPosition = new Vector3(rightAttack1Offset.x * -1, rightAttack1Offset.y);
    }

    public void stopAttack()
    {
        swordColliderAttack01.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SkeletonEnemy") || collision.CompareTag("WolfEnemy") || collision.CompareTag("Wizard"))
        {
            enemyHealth = collision.GetComponent<Level03EnemyHealth>();

            enemyHealth.takeDamage(damage);

        }
    }
}

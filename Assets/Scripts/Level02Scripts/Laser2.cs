using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser2 : MonoBehaviour
{
    private Vector2 targetPosition;
    private PlayerHealth playerHealth;
    public float speed = 1f;

    public int damage = 20;

    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        //moveDirection = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(moveDirection * speed * Time.deltaTime);

    }
    public void setMoveDirection(Vector2 targetPosition)
    {
        moveDirection = (targetPosition - (Vector2)transform.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerHitBox"))
        {
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            playerHealth.takeDamage(damage);

        }
    }

}

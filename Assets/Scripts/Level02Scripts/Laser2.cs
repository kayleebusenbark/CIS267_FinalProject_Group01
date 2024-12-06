using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser2 : MonoBehaviour
{

    private Transform player;
    private LineRenderer lineRenderer;

    PlayerHealth playerHealth;

    public int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        transform.right = direction;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        lineRenderer.SetPosition(0, transform.position);

        if (hit.collider != null)
        {
            lineRenderer.SetPosition(1, hit.point);

            if (hit.collider.CompareTag("Player"))
            {
                //player takes damage here
                playerHealth = gameObject.GetComponent<PlayerHealth>();
                playerHealth.takeDamage(damage);

            }

            else
            {
                lineRenderer.SetPosition(1, transform.position + (Vector3)direction * 10f);
            }
        }

    }
}

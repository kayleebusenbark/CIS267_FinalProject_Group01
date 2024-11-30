using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAI : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float stopDistance = 0.4f;
    public GameObject projectilePrefab;
    public float orbitRadius = 0.5f;
    public float orbitDuration = 2f;
    public int projectileCount = 5;
    public float shootSpeed = 3f;

    private Transform player;
    private bool isAttacking = false;
    private List<GameObject> activeProjectiles = new List<GameObject>();
    private List<Coroutine> orbitCoroutines = new List<Coroutine>();
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        animator = GetComponent<Animator>();
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        if(!isAttacking)
        {
            moveTowardPlayer();
        }
    }

    private void moveTowardPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > stopDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

            animator.SetBool("isWalking", true);
        }

        else
        {
            animator.SetBool("isWalking", false);
            StartCoroutine(attack());

        }

    }

    private IEnumerator attack()
    {
        isAttacking = true;

        for (int i = 0; i < projectileCount; i++)
        {
            float angle = i * Mathf.PI * 2 / projectileCount;

            Vector2 spawnPosition = (Vector2)transform.position + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * orbitRadius;
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
            activeProjectiles.Add(projectile);

            Coroutine orbitCoroutine = StartCoroutine(orbitProjectile(projectile, angle));
            orbitCoroutines.Add(orbitCoroutine);
        }

        yield return new WaitForSeconds(orbitDuration);
        animator.SetTrigger("attack");


        foreach (Coroutine coroutine in orbitCoroutines)
        {
            StopCoroutine(coroutine);
        }

        orbitCoroutines.Clear();

        foreach (GameObject projectile in activeProjectiles)
        {
            if (projectile != null)
            {
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    Vector2 shootDirection = ((Vector2)projectile.transform.position - (Vector2)transform.position).normalized;
                    rb.velocity = shootDirection * shootSpeed;
                }

                Destroy(projectile, 1f);
            }

        }

        activeProjectiles.Clear();

        isAttacking = false;
        animator.SetBool("isWalking", false);

    }

    private IEnumerator orbitProjectile(GameObject projectile, float initialAngle)
    {
        float angle = initialAngle;

        while (projectile != null && isAttacking)
        {
            angle += Time.deltaTime * Mathf.PI;
            Vector2 orbitPosition = (Vector2)transform.position + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * orbitRadius;
            projectile.transform.position = orbitPosition;

            yield return null;  

        }

    }

    public void activateWizard()
    {
        enabled = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movementSpeed;
    private Vector2 movementInput;
    public ContactFilter2D contactFilter;
    public float collisionOffset;
    List<RaycastHit2D> raycastHit2Ds = new List<RaycastHit2D>();
    Animator playerAnimator;
    SpriteRenderer spriteRenderer;

    public GameObject noDestroy;
    public Vector3 spawnPosition;

    private LevelLoader levelLoader;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        if(movementInput != Vector2.zero)
        {
            int raycastHitCount = rb.Cast(movementInput, contactFilter, raycastHit2Ds, movementSpeed * Time.fixedDeltaTime + collisionOffset);

            if (raycastHitCount == 0)
            {
                rb.MovePosition(rb.position + movementInput * movementSpeed * Time.fixedDeltaTime);
            }

            playerAnimator.SetBool("isMoving", true);
        }

        else
        {
            playerAnimator.SetBool("isMoving", false);
        }
        flipSprite();
    }

    private void flipSprite()
    {
        if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }

    }

    void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Emerald"))
        {
            DontDestroyOnLoad(noDestroy);
            spawnPosition = new Vector3(-8.7f, -1.49f, 0f);

            levelLoader.LoadNextLevel();
            StartCoroutine(updatePlayerPositionAfterDelay());
        }
        else if(collision.CompareTag("Sapphire"))
        {
            DontDestroyOnLoad(noDestroy);
            spawnPosition = new Vector3(0f, 1.7f, 0f);

            levelLoader.LoadNextLevel();
            StartCoroutine(updatePlayerPositionAfterDelay());
        }
    }

    private IEnumerator updatePlayerPositionAfterDelay()
    {
        yield return new WaitForSeconds(2.0f);

        transform.position = spawnPosition;
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
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

    private bool hasSwordAndShield = false;

    public PlayerAttack01 attack01;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
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
            tryMove(movementInput);

            updatePlayerAnimations(true);
        }

        else
        {
            updatePlayerAnimations(false);
        }
        flipSprite();
    }

    //this is to help the player slide around objects
    private bool tryMove(Vector2 direction)
    {
        int raycastHitCount = rb.Cast(movementInput, contactFilter, raycastHit2Ds, movementSpeed * Time.fixedDeltaTime + collisionOffset);

        if (raycastHitCount == 0)
        {
            rb.MovePosition(rb.position + movementInput * movementSpeed * Time.fixedDeltaTime);
            return true;
        }
        else
        {
            return false;
        }

    }

    //player weapon check
    private void updatePlayerAnimations(bool isMoving)
    {
        if(hasSwordAndShield)
        {
            playerAnimator.SetBool("isMovingWithSword&Shield", isMoving);
            playerAnimator.SetBool("isMovingWithoutSword&Shield", false);
        }
        else
        {
            playerAnimator.SetBool("isMovingWithSword&Shield", false);
            playerAnimator.SetBool("isMovingWithoutSword&Shield", isMoving);
        }
    }

    private void flipSprite()
    {
        if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
            boxCollider.offset = new Vector2(-Mathf.Abs(boxCollider.offset.x), boxCollider.offset.y);
        }
        else if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
            boxCollider.offset = new Vector2(Mathf.Abs(boxCollider.offset.x), boxCollider.offset.y);
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

            levelLoader.loadNextLevel();
            StartCoroutine(updatePlayerPositionAfterDelay());
        }
        else if(collision.CompareTag("Sapphire"))
        {
            DontDestroyOnLoad(noDestroy);
            spawnPosition = new Vector3(0f, 1.5f, 0f);

            levelLoader.loadNextLevel();
            StartCoroutine(updatePlayerPositionAfterDelay());
        }
        else if(collision.CompareTag("Sword&Shield"))
        {
            hasSwordAndShield = true;
            Destroy(collision.gameObject);
            playerAnimator.SetBool("sword&shieldPickUp", true);
        }
    }

    private IEnumerator updatePlayerPositionAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);

        transform.position = spawnPosition;
    }

    void OnFire()
    {
        if (hasSwordAndShield == true)
        {
            print("firepressed");
            playerAnimator.SetTrigger("attack1LeftMouseClick");
        }

    }

    public void swordAttack()
    {
        if(spriteRenderer.flipX == true)
        {
            attack01.attackLeft();
        }
        else
        {
            attack01.attackRight();
        }
    }

    public void endSwordAttack()
    {
        attack01.stopAttack();
    }
}


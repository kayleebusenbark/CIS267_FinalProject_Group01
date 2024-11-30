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

    private int mouseClickCount = 0;
    private float mouseClickTimer = 0f;
    public float doubleClickTimeLimit = 0.5f;

    private bool isBlocking = false;

    private bool isMouseHeld = false;
    private float mouseHeldTimer = 0f;
    public float attack3Threshold = 1f;

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
        if(mouseClickCount > 0)
        {
            mouseClickTimer += Time.deltaTime;

            if(mouseClickTimer > doubleClickTimeLimit)
            {
                mouseClickCount = 0;
                mouseClickTimer = 0f;
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            if(!isBlocking)
            {
                isBlocking = true;
                triggerBlockAnimation(true);
            }
        }
        else if(Input.GetMouseButtonUp(1))
        {
            if(isBlocking)
            {
                isBlocking = false;
                triggerBlockAnimation(false);
            }
        }
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

            mouseClickCount++;
            mouseClickTimer = 0f;

            if (mouseClickCount == 1)
            {
                playerAnimator.SetTrigger("attack1LeftMouseClick");

            }
            else if (mouseClickCount == 2)
            {
                playerAnimator.SetTrigger("attack2LeftMouseDoubleClick");
                mouseClickCount = 0;
            }

            if(Input.GetMouseButton(0))
            {
                isMouseHeld = true;
                mouseHeldTimer += Time.deltaTime;

                if(mouseHeldTimer >= attack3Threshold)
                {
                    if(!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("attack3LeftMouseDown"))
                    {
                        playerAnimator.SetTrigger("attack3LeftMouseDown");
                    }

                }
            }

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

    private void triggerBlockAnimation(bool isBlocking)
    {
        playerAnimator.SetBool("isBlocking", isBlocking);
    }
}


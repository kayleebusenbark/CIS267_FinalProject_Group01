using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
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

    private int clickCount = 0;
    private float clickTimer = 0f;
    public float doubleClickTimeLimit = 0.5f;

    private bool isBlocking = false;

    private bool isHeld = false;
    private float holdTimer = 0f;
    public float attack3Threshold = 1f;

    private bool canUseAttack3 = false;

    private Inventory inventory;

    public AudioSource source;

    public AudioClip clip;
    public AudioClip clip2;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        levelLoader = FindObjectOfType<LevelLoader>();
        inventory = FindObjectOfType<Inventory>();  
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMovementInput();
        handleAttackInput();
        handleBlockInput();

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

    private void handleMovementInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movementInput = new Vector2(moveX, moveY).normalized;
    }

    private void handleAttackInput()
    {
        if (canUseAttack3 && (Input.GetButton("Fire3") || Input.GetMouseButton(0)))
        {
            isHeld = true;
            holdTimer += Time.deltaTime;

            if (holdTimer >= attack3Threshold)
            {
                if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("attack3LeftMouseHold"))
                {
                    playerAnimator.SetTrigger("attack3LeftMouseHold");
                    holdTimer = 0f;
                    isHeld = false;
                }
            }
        }

        else
        {
            isHeld = false;
            holdTimer = 0f;
        }

        if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0))
        {
            clickCount++;
            clickTimer = 0f;

            if(clickCount == 1)
            {
                playerAnimator.SetTrigger("attack1LeftMouseClick");
            }
            else if(clickCount == 2)
            {
                playerAnimator.SetTrigger("attack2LeftMouseDoubleClick");
                clickCount = 0;
            }
        }

        if (clickCount > 0)
        {
            clickTimer += Time.deltaTime;

            if(clickTimer > doubleClickTimeLimit)
            {
                clickCount = 0;
                clickTimer = 0f;
            }
        }

    }

    private void handleBlockInput()
    {
        if(Input.GetButtonDown("Fire2") || Input.GetMouseButtonDown(1))
        {
            if(!isBlocking)
            {
                isBlocking = true;
                triggerBlockAnimation(true);
            }
        }
        else if(Input.GetButtonUp("Fire2") || Input.GetMouseButtonUp(1))
        {
            if(isBlocking)
            {
                isBlocking = false;
                triggerBlockAnimation(false);
            }
        }
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
        if (collision.CompareTag("Emerald"))
        {
            // source.PlayOneShot(clip);
            Destroy(collision.gameObject);
            inventory.showEmerald();
            DontDestroyOnLoad(noDestroy);
            spawnPosition = new Vector3(-8.7f, -1.49f, 0f);

            levelLoader.loadNextLevel();
            StartCoroutine(updatePlayerPositionAfterDelay());
        }
        else if (collision.CompareTag("Sapphire"))
        {
            // source.PlayOneShot(clip);
            Destroy(collision.gameObject);

            inventory.showSapphire();

            DontDestroyOnLoad(noDestroy);
            spawnPosition = new Vector3(0f, 1.5f, 0f);

            levelLoader.loadNextLevel();
            StartCoroutine(updatePlayerPositionAfterDelay());
        }
        else if (collision.CompareTag("Sword&Shield"))
        {
            hasSwordAndShield = true;
            Destroy(collision.gameObject);
            inventory.showSwordandShield();

            playerAnimator.SetBool("sword&shieldPickUp", true);
        }
        else if (collision.CompareTag("Berries"))
        {
            inventory.showFruit();
        }
        else if (collision.CompareTag("Scroll"))
        {
            canUseAttack3 = true;
            Destroy(collision.gameObject);
            source.PlayOneShot(clip2);
            inventory.showScroll();
        }

        else if (collision.CompareTag("freeze"))
        {
            Freeze freeze = FindObjectOfType<Freeze>();

            freeze.showCanvas();
            Destroy(collision.gameObject);
        }

        else if (collision.CompareTag("Ruby"))
        {
            // source.PlayOneShot(clip);
            Destroy(collision.gameObject);
            inventory.showRuby();

            VictoryScreen screen = FindObjectOfType<VictoryScreen>();
            screen.triggerVictoryScreen();
        }
    }

    private IEnumerator updatePlayerPositionAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);

        transform.position = spawnPosition;
    }


    public void swordAttack()
    {
        if(spriteRenderer.flipX == true)
        {
            attack01.attackLeft();
            source.PlayOneShot(clip);
        }
        else
        {
            attack01.attackRight();
            source.PlayOneShot(clip);
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


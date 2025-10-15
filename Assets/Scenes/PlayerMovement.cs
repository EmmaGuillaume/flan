using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 2f;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    public GameObject interactionPromptUI;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // --- Déplacement horizontal ---
        float moveInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * moveInput * moveSpeed * Time.deltaTime);

        float moveInputJump = Input.GetAxisRaw("Vertical");


        bool isWalking = Mathf.Abs(moveInput) > 0;


        anim.SetBool("isWalking", isWalking);

        // --- Animation jump ---

        // --- Flip sprite ---
        if (moveInput > 0)
            sr.flipX = false;
        else if (moveInput < 0)
            sr.flipX = true;


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jump key was pressed");

            //anim.SetBool("isJumping", !isGrounded);

            // Reset vitesse verticale avant d'appliquer le saut
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

            // Appliquer une impulsion constante
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            //anim.SetTrigger("Jump");
        }



        // --- Gestion état en l’air (fall) ---
        if (!isGrounded && rb.linearVelocity.y < 0)
        {
            //anim.SetBool("isFalling", true);
        }
        else
        {
            //anim.SetBool("isFalling", false);
        }
    }
    
     private void OnCollisionStay2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            interactionPromptUI.SetActive(true);
            collision.gameObject.GetComponent<IInteractable>()?.Interact();
        }
        else
        {
            interactionPromptUI.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //anim.SetBool("isJumping", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
           // anim.SetBool("isJumping", true);
        }
    }
}

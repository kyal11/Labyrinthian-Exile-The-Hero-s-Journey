using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TrailRenderer tr;
    [SerializeField] public Animator animator;
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] private CircleCollider2D circleCollider;

    public Rigidbody2D playerRb;
    public float speed;
    public float input;
    public bool jump=false;
    public float jumpForce;
    public LayerMask groundLayer;
    private bool wasGrounded;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;
    public SpriteRenderer spriteRenderer;

    // Dash
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 15f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.2f;
    private Vector2 dashDirection = Vector2.right;

    void Start()
    {
        // Disable the circle collider at the start
        circleCollider.enabled = false;

        // Enable the capsule collider at the start
        capsuleCollider.enabled = true;
    }
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");

        if (input < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (input > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Check if player is grounded and can jump
        bool wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Jump", true);
            playerRb.velocity = Vector2.up * jumpForce;
        }else if(!wasGrounded && isGrounded)
        {
            
            animator.SetBool("Jump", false);
        }

      

        // Check if player is dashing or jumping
        if (isDashing || !isGrounded)
        {
            if (isDashing)
            {
                capsuleCollider.enabled = false;
                // Enable the circle collider
                circleCollider.enabled = true;
                animator.SetBool("Dash", true);
            }
            return;
        }
        else
        {
            // Disable the circle collider after dashing
            circleCollider.enabled = false;
            // Enable the capsule collider after dashing
            capsuleCollider.enabled = true;
            animator.SetBool("Dash", false);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            // Determine dash direction based on player input
            if (input == 0)
            {
                dashDirection = spriteRenderer.flipX ? Vector2.left : Vector2.right;
            }
            else
            {
                dashDirection = input > 0 ? Vector2.right : Vector2.left;
            }
            StartCoroutine(Dash());
        }
     
        //Animation
        animator.SetFloat("Speed", Mathf.Abs(input));
        
    }

    void FixedUpdate()
    {
        // Check if player is dashing or jumping
        if (isDashing || !isGrounded)
        {
            return;
        }
        playerRb.velocity = new Vector2(input * speed, playerRb.velocity.y);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = playerRb.gravityScale;
        playerRb.gravityScale = 0f;
        playerRb.velocity = dashDirection * dashingPower;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        playerRb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Collider2D groundCheckCollder;
    [SerializeField] private LayerMask groundLayer = ~0;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpHeight = 10f;
    
    [Header("Graphics")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    
    private Vector2 velocity;
    private Vector2 moveInput;
    private bool isGrounded = false;
    private bool wasGrounded = false;
    private bool jumpRequested = false;
    private bool jumpReleased = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigidBody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement
        velocity.x = moveInput.x * speed;
        rigidBody.linearVelocity = velocity;
        // Handle flip in x
        if (spriteRenderer)
        {
            if (velocity.x > 0.01f)
            {
                spriteRenderer.flipX = false;
            }
            else if (velocity.x < -0.01f) 
            {
                spriteRenderer.flipX = true;
            }
        }
        
        //
        isGrounded = IsGrounded();
        ApplyGravity();
        if (wasGrounded && jumpRequested)
        {
            jumpRequested = false;
            velocity.y = jumpHeight;
        }
        wasGrounded = isGrounded;
        
    }


    private void ApplyGravity()
    {
        if (isGrounded && velocity.y < 0.0f)
        {
            velocity.y = -1f;
        }
        else
        {
            // If jumping
            if (velocity.y > 0.0f)
            {
                float deacceleration = 1f;
                if (jumpReleased)
                {
                    deacceleration = 5f;
                }
                velocity.y += Physics.gravity.y * deacceleration * Time.deltaTime;
            }
            // If falling
            else
            {
                velocity.y += Physics.gravity.y * Time.deltaTime;
            }
        }
    }
    
    private bool IsGrounded()
    {
        return groundCheckCollder.IsTouchingLayers(groundLayer);
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumpRequested = true;
            jumpReleased = false;
        }
        else if (context.canceled)
        {
            jumpRequested = false;
            jumpReleased = true;
        }
    }
}

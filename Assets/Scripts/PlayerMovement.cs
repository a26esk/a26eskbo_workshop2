using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Collider2D collider;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpHeight = 3f;
    
    [Header("Graphics")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    
    private Vector2 velocity;
    private Vector2 moveInput;
    private bool isGrounded = false;
    private bool wasGrounded = false;
    private bool jumpRequested = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}

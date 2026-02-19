using UnityEngine;
// define x axis to make floor 

public class PlayerCharacterControls : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    private float moveX;

    [Header("Jumping")]
    public float jumpForce = 7f;
    private bool isGrounded;

    [Header("Ground Check")]
    public Transform groundCheck;      // empty object at player's feet
    public float checkRadius = 0.2f;   // small circle to check for ground
    public LayerMask groundLayer;      // set this to the layer your floor is on

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal input
        moveX = Input.GetAxisRaw("Horizontal");

        // Check if player is touching the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // Apply horizontal movement
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
    }
} 

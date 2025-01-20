using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variable for horizontal movement / Running etc. 
    public float moveSpeed = 10.0f;

    // Variable for vertical movement / Jumping etc.
    public float jumpForce = 10.0f;
    // Variable to check if the player can double jump
    private bool canDoubleJump;

    // Variable to check if the player is on the ground
    private bool isGrounded;
    // Reference to the ground point Transform
    public Transform groundCheckPoint;
    // What is considered as ground
    public LayerMask whatIsGround;

    // Reference to the SpriteRenderer component
    private SpriteRenderer theSR;
    // Reference to the Animator component
    private Animator anim;
    // Reference to the Rigidbody2D component
    public Rigidbody2D theRB;

    
    void Start()
    {
        // Get the Rigidbody2D component from the GameObject
        theRB = GetComponent<Rigidbody2D>();
        // Get the Animator component from the GameObject
        anim = GetComponent<Animator>();
        // Get the SpriteRenderer component from the GameObject
        theSR = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        // Move the player left or right based on the horizontal input
        theRB.linearVelocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.linearVelocity.y);

        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);

        // Resetting the double jump if the player is on the ground
        if (isGrounded)
        {
            canDoubleJump = true;
        }

        // If the player is on the ground and the jump button is pressed
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                // Command for the player to jump
                theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, jumpForce);
            }
            else
            {
                // Make player can jump again if they are in the air for once
                if (canDoubleJump)
                {
                    // Command for the player to jump
                    theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, jumpForce);
                    // Set the double jump to false so Player can't double jump infinitely
                    canDoubleJump = false;
                }
            }
        }

        if (theRB.linearVelocity.x < 0)
        {
            theSR.flipX = true;
        }
        else if (theRB.linearVelocity.x > 0)
        {
            theSR.flipX = false;
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.linearVelocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }
}

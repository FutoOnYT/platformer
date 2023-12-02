using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float HorizontalInput;
    [SerializeField]
    float Speed = 20;
    Rigidbody2D rb;


    public KeyCode slideKey = KeyCode.C;
    public KeyCode jumpKey = KeyCode.Space;
    public float slideForce;
    public float jumpForce;
    bool canJump = true;
    public bool jumping;
    bool alreadyJumped;

    private bool isWallSliding;
    private float wallSlidingSpeed = 1.5f;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    private bool isWallJumping;
    private float wallJumpingDirect;
    private float wallJumpingTime = .2f;
    private float wallJumpingCounter;   
    private float wallJumpingDuration = .4f;
    private Vector2 wallJumpingPower = new Vector2(20f, .05f); 

    bool isGrounded;
    bool walking;

    private Collider2D collider;
    public Animator anim;


    public Vector2 jumpHeight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            isGrounded = true;
        }
        else if (!collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            isGrounded = false;
        }

        if (Input.GetKeyDown(slideKey))
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, (gameObject.transform.localScale.y / 2));
            rb.AddForce(Vector2.down * 10);
            Debug.Log("Slide");
            if (HorizontalInput > 0)
            {
                rb.AddRelativeForce(Vector2.right * slideForce, ForceMode2D.Impulse);


            }
            else if (HorizontalInput < 0)
            {
                rb.AddRelativeForce(Vector2.left * slideForce, ForceMode2D.Impulse);


            }


          

        }
        else if (Input.GetKeyUp(slideKey))
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, (gameObject.transform.localScale.y * 2));

        }

        if (Input.GetKeyDown(jumpKey))
        {
            if (!jumping)
            {
                jumping = true;
                alreadyJumped = false;
                anim.SetTrigger("Jump");
            }
        }


        if (HorizontalInput > 0)
        {
            gameObject.transform.localScale = new Vector3(0.36f, 0.36f, 0.36f);
            anim.SetBool("walking", true);
            walking = true;
        }
        if (HorizontalInput < 0)
        {
            gameObject.transform.localScale = new Vector3(-0.36f, 0.36f, 0.36f);
            anim.SetBool("walking", true);
            walking = true;
        }

        if (HorizontalInput == 0)
        {
            anim.SetBool("walking", false);

        }

        wallSlide(); 
        wallJump(); 
    }

    private void FixedUpdate()
    {
        if (!isWallSliding)
        {
            HorizontalInput = Input.GetAxis("Horizontal");
            float horizontalMovement = HorizontalInput * (Speed * 10) * Time.deltaTime;
            //   rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
            rb.velocity = new Vector2(horizontalMovement * (Speed * 10), rb.velocity.y);
        }

        if (jumping && !alreadyJumped)
        {
            rb.AddForce(Vector2.up * (jumpForce * 100), ForceMode2D.Force);

            alreadyJumped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumping = false;
            //    alreadyJumped = false;
        }
    }

    private void wallSlide()
    {
        if (touchingWall() && !isGrounded)
        {
            isWallSliding = true;    
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void wallJump()
    {
        if(isWallSliding == true)
        {
            isWallJumping = false;
            wallJumpingDirect = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime; 

            CancelInvoke(nameof(stopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(jumpKey) && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirect * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;


            Invoke(nameof(stopWallJumping), wallJumpingDuration); 
        }
    }

    private void stopWallJumping()
    {
        isWallJumping = false;
    }

    private bool touchingWall()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer); 
    }
}

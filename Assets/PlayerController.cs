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
    bool jumping;
    bool alreadyJumped;
    public GameObject playerObj;

    bool isGrounded;

    private Collider2D collider;


    public Vector2 jumpHeight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        collider = GetComponent<Collider2D>();
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
            playerObj.transform.localScale = new Vector3(1, 0.5f);
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

        if(Input.GetKeyUp(slideKey))
        {
            playerObj.transform.localScale = new Vector3(1, 1f);

        }

        if(Input.GetKeyDown(jumpKey))
        {
            if (!jumping)
            {
                jumping = true;
                alreadyJumped = false;
            }
        }


        if(HorizontalInput > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if(HorizontalInput < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        float horizontalMovement = HorizontalInput * (Speed * 10) * Time.deltaTime;
     //   rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
        rb.velocity = new Vector2(horizontalMovement * (Speed * 10), rb.velocity.y);

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
}

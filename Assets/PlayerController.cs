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
    public GameObject playerObj;

    public Vector2 jumpHeight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
        else if(Input.GetKeyUp(jumpKey))
        {
            jumping = false;
        }

    }

    private void FixedUpdate()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        float horizontalMovement = HorizontalInput * (Speed * 10) * Time.deltaTime;
     //   rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
        rb.AddForce(new Vector2(horizontalMovement, rb.velocity.y), ForceMode2D.Impulse);

       
    }



    void Jump()
    {
        Debug.Log("Adding Force");
        rb.AddRelativeForce(jumpHeight, ForceMode2D.Impulse);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 mousePos;

    Vector2 Position = new Vector2(0f, 0f); 

    public bool isPlacing = false; 

    [SerializeField] private float moveSpeed = .5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        isPlacing = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePos = Input.mousePosition; 
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Position = Vector2.Lerp(transform.position, mousePos, moveSpeed); 

    }


    private void FixedUpdate()
    {
        if(isPlacing == true)
        {
            rb.simulated = true;
            rb.MovePosition(Position); 
        }
    }


    
}

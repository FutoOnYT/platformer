using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector3 mousePos;

    Vector2 Position = new Vector2(0f, 0f); 

    public bool isPlacing = false; 

    [SerializeField] private float moveSpeed = .5f;

    private void Start()
    {
        isPlacing = false; 
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
            rb.MovePosition(Position); 
        }
    }


    public void placing()
    {
        isPlacing = true;
    }
}

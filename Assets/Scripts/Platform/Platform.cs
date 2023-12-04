using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 mousePos;
    private Vector3 targetPos;
    GameObject cameraObj;

    Vector2 Position = new Vector2(0f, 0f); 

    public bool isPlacing = false;

    float mouseX;
    float mouseY;

    [SerializeField] private float moveSpeed = .5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        isPlacing = true;
        rb = GetComponent<Rigidbody2D>();
        cameraObj = GameObject.FindGameObjectWithTag("Cinemachine Brain");
    }

    private void Update()
    {
        mousePos = Input.mousePosition; 
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouseX = mousePos.x + cameraObj.transform.localPosition.x;
        mouseY = mousePos.y + cameraObj.transform.localPosition.y;

        targetPos = new Vector3(mouseX, mouseY, mousePos.z);

        Position = Vector2.Lerp(transform.position, targetPos, moveSpeed); 

    }


    private void FixedUpdate()
    {
        if(isPlacing == true)
        {
            Debug.Log("targetPos: " + targetPos);
            Debug.Log("mousePos: " + mousePos);
            rb.MovePosition(Position);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }


    
}

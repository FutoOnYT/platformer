using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBlock : MonoBehaviour
{

    public float padForce = 15f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Pad");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("PadPLAYER");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * padForce, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * padForce, ForceMode2D.Impulse);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            gameObject.GetComponent<Animator>().SetTrigger("JumpPad");
            Invoke("Ready", 3f);
        }
    }


    void Ready()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        
    }
}

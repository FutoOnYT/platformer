using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    PlayerController playerController;
    Animator animator;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.tag == "Ground") && (playerController.jumping))
        {
            StartCoroutine(vault(collision));
        }
    }

    IEnumerator vault(Collider2D collision)
    {
        animator.SetTrigger("Vault");
        yield return new WaitForSeconds(0.1f);
        playerController.gameObject.transform.position = collision.GetComponent<Ground>().vaultPosition.transform.position;
    }
}

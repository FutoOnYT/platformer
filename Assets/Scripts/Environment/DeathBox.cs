using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{

    public GameObject deathScreen;
    public GameObject deathParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(deathParticles);
            deathParticles.transform.position = collision.transform.localPosition;
            collision.gameObject.SetActive(false);
            Invoke("DeathScreen", 2.0f);
        }
    }

    void DeathScreen()
    {
        deathScreen.SetActive(true);
    }
}

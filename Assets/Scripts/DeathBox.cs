using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{

    public GameObject deathScreen;
    public GameObject deathParticles;

    public CameraShake shake;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(deathParticles);
            shake.TriggerShake(1);
            deathParticles.transform.position = collision.transform.position;
            collision.gameObject.SetActive(false);
      //      Invoke("DeathScreen", 2.0f);
        }
    }

    void DeathScreen()
    {
        deathScreen.SetActive(true);
    }
}

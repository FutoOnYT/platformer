using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{

    public GameObject deathScreen;
    public GameObject deathParticles;

    public GameObject player;

    Vector2 playerPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject particles = Instantiate(deathParticles);
            particles.transform.position = playerPos;
            collision.gameObject.SetActive(false);
            Invoke("DeathScreen", 2.0f);
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        playerPos = player.transform.position;
    }

    void DeathScreen()
    {
        deathScreen.SetActive(true);
    }
}

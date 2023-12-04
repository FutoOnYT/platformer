using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    GameObject player;
    public GameObject endUI;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.SetActive(false);
            endUI.SetActive(true);
        }
    }


    public void Nextlevel()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

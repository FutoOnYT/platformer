using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Buttons : MonoBehaviour
{
    public GameObject mainMenu; 
    public GameObject levels;

    private bool isLevelscreen = false;

    private void Start()
    {
        mainMenu.SetActive(true);
        levels.SetActive(false);
    }
    public void levelScreen()
    {
        if (!isLevelscreen)
        {
            levels.SetActive(true);
            mainMenu.SetActive(false);
            isLevelscreen = true;
        }
        else
        {
            levels.SetActive(false);
            mainMenu.SetActive(true);
            isLevelscreen = false;
        }
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }

}

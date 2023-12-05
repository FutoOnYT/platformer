using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlatformButton : MonoBehaviour
{
    public PlatformController platController;

    private float cooldown; 
    private bool isReady = true;

    public Color onCD;
    public Color offCD;
    public Button Button;

    public GameObject placeMenu;


    void Start()
    {
        platController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlatformController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReady)
        {
            cooldown -= Time.deltaTime;
            if (cooldown < 0)
            {
                isReady = true;
                //ChangeColour();
            }
        }
    }

    public void StartPlace()
    {
        Debug.Log("Start Place");

        if (isReady == true)
        {
            placeMenu.SetActive(true);

            //platController.buttonPressed = true;
            //platController.placePlatform();
            //cooldown = 1.5f;
            //isReady = false;
            //ChangeColour();
        }
    }

    //void ChangeColour()
    //{
    //    ColorBlock cb = Button.colors;
    //    if (isReady == true)
    //    {
    //        cb.normalColor = offCD;
    //        cb.highlightedColor = offCD;
    //        cb.pressedColor = offCD;
    //        Button.colors = cb;
    //    }
    //    else if (isReady == false) 
    //    {
    //        cb.normalColor = onCD;
    //        cb.highlightedColor = onCD;
    //        cb.pressedColor= onCD;
    //        cb.selectedColor = onCD;
    //        Button.colors = cb;   
    //    }
    //}
}

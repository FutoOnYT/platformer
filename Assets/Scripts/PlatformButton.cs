using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButton : MonoBehaviour
{
    public PlatformController platController;
    void Start()
    {
        platController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlatformController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartPlace()
    {
        Debug.Log("Start Place");
        platController.buttonPressed = true;
        platController.placePlatform();
    }
}

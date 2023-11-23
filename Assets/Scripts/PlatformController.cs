using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    public Platform platScript;

    public bool isPlacing;
    public bool buttonPressed;

    GameObject recentlyPlaced;

    public Vector3 mousePos;
    Vector3 placePos;

    [SerializeField] Camera mainCam;
 
    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
 
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);


        
        if(recentlyPlaced != null)
        {
            if ((Input.GetMouseButtonDown(0)) && recentlyPlaced.GetComponent<Platform>().isPlacing)
            {
                Debug.Log("Disable");
                recentlyPlaced.GetComponent<Platform>().rb.simulated = false;
                buttonPressed = false;
                recentlyPlaced.GetComponent<Platform>().isPlacing = false;
            }
        }
      
    }
    public void placePlatform()
    {
        Debug.Log("placePlatform");
        Vector3 placePos = new Vector3(mousePos.x, mousePos.y, 0);
        Vector3 rotation = mousePos - transform.position;
        recentlyPlaced = Instantiate(platform, placePos, Quaternion.identity);
        platScript = recentlyPlaced.GetComponent<Platform>();
        recentlyPlaced.GetComponent<Platform>().isPlacing = true;
    }

}

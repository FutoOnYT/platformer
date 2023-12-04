using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    public Platform platScript;

    public bool isPlacing;
    public bool buttonPressed;

    public GameObject cameraObj;

    GameObject recentlyPlaced;

    public Vector3 mousePos;
    float mouseX;
    Vector3 placePos;

    [SerializeField] Camera mainCam;
 
    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
 
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        mouseX = mousePos.x + cameraObj.transform.localPosition.x;
        
        if(recentlyPlaced != null)
        {
            if ((Input.GetMouseButtonDown(0)) && recentlyPlaced.GetComponent<Platform>().isPlacing)
            {
                Debug.Log("Disable");
                buttonPressed = false;
                recentlyPlaced.GetComponent<Platform>().isPlacing = false;
                recentlyPlaced.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
      
    }
    public void placePlatform()
    {
        Debug.Log("placePlatform");
        Vector3 placePos = new Vector3(mouseX, mousePos.y, 0);
        Vector3 rotation = mousePos - transform.position;
        recentlyPlaced = Instantiate(platform, placePos, Quaternion.identity);
        platScript = recentlyPlaced.GetComponent<Platform>();
        recentlyPlaced.GetComponent<Platform>().isPlacing = true;
    }

}

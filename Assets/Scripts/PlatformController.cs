using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Object platform;
    public Platform platScript; 

    public Vector3 mousePos; 

    [SerializeField] Camera mainCam;
 
    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
 
    }

    private void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
    public void placePlatform()
    {
        Vector3 rotation = mousePos - transform.position;
        Instantiate(platform, mousePos, Quaternion.identity);
        platScript.placing(); 
    }

}

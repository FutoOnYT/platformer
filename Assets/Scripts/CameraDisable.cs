using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDisable : MonoBehaviour
{
    public GameObject camBrain;
    public GameObject camObj;
    public GameObject debugFollow;
    void Start()
    {
        camBrain = GameObject.FindGameObjectWithTag("Cinemachine Brain");
        camObj = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            camBrain.GetComponent<CinemachineVirtualCamera>().Follow = null;
            camBrain.GetComponent<CinemachineVirtualCamera>().enabled = false;
        }
    }

}

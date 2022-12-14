using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    //public GameObject crosshair;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SwitchCam1"))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
        if (Input.GetButtonDown("SwitchCam2"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }

        /*
        if(cam1.activeSelf == true)
        {
            crosshair.SetActive(false);
        }
        else
        {
            crosshair.SetActive(true);
        }
        */
    }
}

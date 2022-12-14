using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject crosshair;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Pause the game when the player presses escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                Cursor.visible = true;
                crosshair.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                Cursor.visible = false;
                crosshair.SetActive(true);
            }
        }
        
    }
}

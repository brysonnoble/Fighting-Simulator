using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject pMenu;

    void Start()
    {
        pMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pMenu.activeSelf == true)
            {
                Time.timeScale = 1;
                pMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pMenu.SetActive(true);
            }
        }
    }

    public void onResumePress()
    {
        Time.timeScale = 1;
        pMenu.SetActive(false);
    }

    public void onMMPress()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void onQuitPress()
    {
        Application.Quit();
    }
}

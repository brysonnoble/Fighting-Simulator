using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject all;
    public GameObject HTP;

    private void Start()
    {
        HTP.SetActive(false);
    }

    public void onHTPPress()
    {
        all.SetActive(false);
        HTP.SetActive(true);
    }

    public void onBackPress()
    {
        all.SetActive(true);
        HTP.SetActive(false);
    }

    public void onPlayPress()
    {
        SceneManager.LoadScene("1v1");
    }

    public void onQuitPress()
    {
        Application.Quit();
    }

}

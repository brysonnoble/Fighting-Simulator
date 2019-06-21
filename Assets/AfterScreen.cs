using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AfterScreen : MonoBehaviour
{

    public Text winStr;
    public Text score;
    public Button mm;

    // Update is called once per frame
    void Start()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("win") == 2)
        {
            winStr.text = "Player 1 wins!";
        }
        else
        {
            winStr.text = "Player 2 wins!";
        }
        score.text = (3 - PlayerPrefs.GetInt("RedLives")) + " - " + (3 - PlayerPrefs.GetInt("BlueLives"));
    }

    public void onMMPress()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

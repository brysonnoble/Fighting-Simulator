using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private float timeLeft = 1f;

    public GameObject p1;
    public GameObject p2;
    public GameObject prefabP1;
    public GameObject prefabP2;

    public Camera cam;

    void Start()
    {
        PlayerPrefs.SetInt("BlueLives", 3);
        PlayerPrefs.SetInt("RedLives", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (p1 == null)
        {
            p1 = Instantiate(prefabP1, new Vector3(0, 0, 0), Quaternion.identity);
            cam.GetComponent<smoothCamera>().setP1(p1.transform);
            GetComponent<HealthCont>().setP1(p1.GetComponent<BasePlayer>());
        }
        if (p1.transform.position.y <= -5 || p1.transform.position.x >= 10 || p1.transform.position.x <= -10)
        {
            Destroy(p1);
            PlayerPrefs.SetInt("BlueLives", PlayerPrefs.GetInt("BlueLives") - 1);
            p1 = null;
        }
        if (p2 == null)
        {
            print(prefabP2 == null);
            p2 = Instantiate(prefabP2, new Vector3(0, 0, 0), new Quaternion(0, 180, 0, 0));
            cam.GetComponent<smoothCamera>().setP2(p2.transform);
            GetComponent<HealthCont>().setP2(p2.GetComponent<BasePlayer>());
        }
        if (p2.transform.position.y <= -5 || p2.transform.position.x >= 10 || p2.transform.position.x <= -10)
        {
            Destroy(p2);
            PlayerPrefs.SetInt("RedLives", PlayerPrefs.GetInt("RedLives") - 1);
            p2 = null;
        }
        CheckP1();
        CheckP2();
        CheckLives();
    }

    void CheckP1()
    {
        if(p1 == null)
        {
            return;
        }
        if (p1.GetComponent<P1Controller>().health <= 0f)
        {
            Destroy(p1);
            PlayerPrefs.SetInt("BlueLives", PlayerPrefs.GetInt("BlueLives") - 1);
            p1 = null;
        }
    }
    void CheckP2()
    {
        if(p2 == null)
        {
            return;
        }
        if (p2.GetComponent<AI>().health <= 0f)
        {
            Destroy(p2);
            PlayerPrefs.SetInt("RedLives", PlayerPrefs.GetInt("RedLives") - 1);
            p2 = null;
        }
    }

    void CheckLives()
    {
        if(PlayerPrefs.GetInt("BlueLives") == 0)
        {
            Time.timeScale = 0.5f;
            PlayerPrefs.SetInt("win", 1);
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0f)
            {
                GameOver();
            }
        }
        if (PlayerPrefs.GetInt("RedLives") == 0)
        {
            Time.timeScale = 0.5f;
            PlayerPrefs.SetInt("win", 2);
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0f)
            {
                Time.timeScale = 1f;
                GameOver();
            }
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("afterGame");
    }
}

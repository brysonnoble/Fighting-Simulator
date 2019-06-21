using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCont : MonoBehaviour
{

    public Image p1Health;
    public Image p2Health;
    public Text p1Text;
    public Text p2Text;
    public Image b1;
    public Image b2;
    public Image b3;
    public Image r1;
    public Image r2;
    public Image r3;

    private RectTransform p1HealthImg;
    private RectTransform p2HealthImg;

    public BasePlayer p1, p2;

    void Start()
    {
        p1HealthImg = p1Health.GetComponent<RectTransform>();
        p2HealthImg = p2Health.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        p1HealthImg.sizeDelta = new Vector2(p1.health, 100);
        p1Text.text = Mathf.Round(p1.health).ToString();
        p2HealthImg.sizeDelta = new Vector2(p2.health, 100);
        p2Text.text = Mathf.Round(p2.health).ToString();
        checkLives();
    }

    public void setP1(BasePlayer p)
    {
        p1 = p;
    }

    public void setP2(BasePlayer p)
    {
        p2 = p;
    }

    void checkLives()
    {
        if(PlayerPrefs.GetInt("BlueLives") == 2)
        {
            Destroy(b3);
        }
        if (PlayerPrefs.GetInt("BlueLives") == 1)
        {
            Destroy(b2);
        }
        if (PlayerPrefs.GetInt("BlueLives") == 0)
        {
            Destroy(b1);
        }
        if (PlayerPrefs.GetInt("RedLives") == 2)
        {
            Destroy(r3);
        }
        if (PlayerPrefs.GetInt("RedLives") == 1)
        {
            Destroy(r2);
        }
        if (PlayerPrefs.GetInt("RedLives") == 0)
        {
            Destroy(r1);
        }
    }
}

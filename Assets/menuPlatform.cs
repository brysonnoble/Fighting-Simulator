using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuPlatform : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector2(0, Random.Range(0.5f, -0.5f) * Time.deltaTime));
        if (transform.position.y >= -3.65)
        {
            transform.Translate(new Vector2(0, Random.Range(-0.5f, -0.1f) * Time.deltaTime));
        }
        if (transform.position.y <= -3.1)
        {
            transform.Translate(new Vector2(0, Random.Range(0.1f, 0.5f) * Time.deltaTime));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformHover : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, Random.Range(0.5f, -0.5f) * Time.deltaTime));
        if(transform.position.y >= 0.4)
        {
            transform.Translate(new Vector2(0, Random.Range(-0.5f, -0.1f) * Time.deltaTime));
        }
        if (transform.position.y <= -0.15)
        {
            transform.Translate(new Vector2(0, Random.Range(0.1f, 0.5f) * Time.deltaTime));
        }
    }
}

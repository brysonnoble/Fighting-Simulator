using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowCont : MonoBehaviour
{

    public GameObject parent;

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation.y == 1)
        {
            transform.localPosition += new Vector3(-7f * Time.deltaTime, 0, 0);
            print(transform.rotation.y);
        }
        else
        {
            transform.localPosition += new Vector3(7f * Time.deltaTime, 0, 0);
            print(transform.rotation.y);
        }
        Destroy(gameObject, 3);
    }
}

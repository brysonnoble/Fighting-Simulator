using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordCont : MonoBehaviour
{

    public GameObject parent;

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.y == 1)
        {
            transform.Rotate(new Vector3(0, 0, 1) * 10f);
            print(transform.rotation);
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, 1) * 10f);
        }
        Destroy(gameObject, 0.25f);
    }
}

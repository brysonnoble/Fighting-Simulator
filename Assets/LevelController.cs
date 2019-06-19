using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;
    public GameObject prefabP1;
    public GameObject prefabP2;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p1.transform.position.y <= -5 || p1.transform.position.x >= 10 || p1.transform.position.x <= -10)
        {
            Destroy(p1);
            p1 = null;
        }
        if (p1 == null)
        {
            p1 = Instantiate(prefabP1, new Vector3(0, 0, 0), Quaternion.identity);
            cam.GetComponent<smoothCamera>().setP1(p1.transform);
        }
        if (p2.transform.position.y <= -5 || p2.transform.position.x >= 10 || p2.transform.position.x <= -10)
        {
            Destroy(p1);
            p2 = null;
        }
        if (p2 == null)
        {
            p2 = Instantiate(prefabP1, new Vector3(0, 0, 0), Quaternion.identity);
            cam.GetComponent<smoothCamera>().setP1(p1.transform);
        }
    }
}

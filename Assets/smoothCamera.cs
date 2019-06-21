using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothCamera : MonoBehaviour
{

    public List<Transform> targets;

    public Vector3 offset = new Vector3(0, 0, -1);
    public float smoothTime = 0.5f;

    private Vector3 velocity;

    void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        Move();
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    Vector3 GetCenterPoint()
    {
        if(targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

    public void setP1(Transform p1)
    {
        targets[0] = p1;
    }

    public void setP2(Transform p2)
    {
        targets[1] = p2;
    }

}

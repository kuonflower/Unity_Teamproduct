using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpin : Trap
{
    float step;
    bool goBack = false;
    Vector3 origin;
    Vector3 destination;

    [SerializeField]
    float speed;

    [SerializeField]
    float rotateX;

    [SerializeField]
    float rotateY;

    [SerializeField]
    float rotateZ;

    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(new Vector3(rotateX, rotateY, rotateZ));

        if (stop)
        {
            return;
        }
        step = speed * Time.deltaTime;
    }
}

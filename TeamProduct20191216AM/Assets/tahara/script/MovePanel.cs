﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanel : Trap
{
    [SerializeField]
    float moveX;
    [SerializeField]
    float moveY;
    [SerializeField]
    float moveZ;
    [SerializeField]
    float speed;

    public static bool PanelMoveStay = false;

    float step;
    bool goBack = false;
    Vector3 origin;
    Vector3 destination;

    protected override void Start()
    {
        origin = transform.position;
        destination = new Vector3(origin.x - moveX, origin.y - moveY, origin.z - moveZ);
    }


    protected override void Update()
    {
        if (PanelMoveStay)
        {

            if (stop)
            {
                return;
            }
            step = speed * Time.deltaTime;

            if (!goBack)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, step);

                if (transform.position == destination)
                {
                    goBack = true;
                    StartCoroutine(Wait());
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, origin, step);

                if (transform.position == origin)
                {
                    goBack = false;
                    StartCoroutine(Wait());
                }
            }
        }
    }
        
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        // Player                            // 
        other.gameObject.transform.SetParent(gameObject.transform);
        Debug.Log("other1中"　+ other);
        }
    Debug.Log("other1外" + other);
    }

    protected virtual void OnTriggerExit(Collider other)
    {
    if (other.gameObject.CompareTag("Player"))
    {
    other.gameObject.transform.SetParent(null);
    }
    }
}


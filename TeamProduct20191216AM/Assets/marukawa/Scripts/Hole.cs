using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    bool goal;

    public string activeTag;

    public bool IsGoal()
    {
        return goal;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == activeTag)
        {
            goal = true;
        }

    }
   /* void OnTriggerStay(Collider other)
    {
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        Vector3 direction = transform.position - other.gameObject.transform.position;

        if(other.gameObject.tag == activeTag)
        {
            r.velocity *= 0.9f;

            r.AddForce(direction * r.mass * 20.0f);
        }else{
            r.AddForce(-direction * r.mass * 80.0f);
        }
    }*/
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}

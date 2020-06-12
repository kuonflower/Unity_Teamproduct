using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAreaLockIn : MonoBehaviour
{
    public GameObject Elevator;
    public string Enemy;

    void Start()
    {
  
    }


    void Update()
    {

    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Elevater.flag = true;
        }

        Debug.Log("Exit" + Elevater.flag);
    }

    void OnTriggeEnter(Collider other)
    {
       

        Debug.Log("Enter" + Elevater.flag);
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay" + Elevater.flag);
    }
}

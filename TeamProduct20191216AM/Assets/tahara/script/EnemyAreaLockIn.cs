using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAreaLockIn : MonoBehaviour
{
    public GameObject Elevator;
    //public string Enemy;
    public Collider other;

    void Start()
    {
  
    }


    void Update()
    {
                if (this.other == null)
        {
            Elevater.flag = true;
            
            //GameObject Enemy = GameObject.FindGameObjectWithTag("Enemy");
            //if (Enemy == null)
            //{
                
            //}
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            this.other = other;
        }
    
    }
}


//void OnTriggerExit(Collider other)
//{
//    if(other.gameObject.tag == "Enemy")
//    {
//        Elevater.flag = true;
//    }

//    Debug.Log("Exit" + Elevater.flag);
//}

//void OnTriggeEnter(Collider other)
//{


//    Debug.Log("Enter" + Elevater.flag);
//}

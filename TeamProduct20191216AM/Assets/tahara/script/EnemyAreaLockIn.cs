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
        Debug.Log("Updateの中身 this.other :" + this.other  );
        if (this.other == null)
        {
            Elevater.flag = true;
            Debug.Log("null" + Elevater.flag);
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
            Debug.Log("オントリガーステイの中身 this.other :" + this.other + "other :" + other);
            Debug.Log("オントリガーステイ　other" + Elevater.flag);
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

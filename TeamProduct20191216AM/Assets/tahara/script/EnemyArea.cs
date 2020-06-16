using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    private GameObject[] Enemy;

    void Start()
    {
        
    }


    void Update()
    {
        GameObject Enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(Enemy == null)
        {
            Elevater.flag = true;
        }
    }
}

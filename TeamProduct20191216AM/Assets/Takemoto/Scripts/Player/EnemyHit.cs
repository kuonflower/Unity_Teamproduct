using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField]
    int attackPower;

    Status enemyStatus;         // 敵のステータス
    private GameObject enemy;   // 敵となるオブジェクト

    //オブジェクトと接触した瞬間に呼び出される
    void OnTriggerEnter(Collider other)
    {
        
   
        //攻撃した相手がEnemyの場合
        if (other.CompareTag("Enemy"))
        {

            enemyStatus.Damage(attackPower);
            Debug.Log("HPだよ");

        }
    }
}

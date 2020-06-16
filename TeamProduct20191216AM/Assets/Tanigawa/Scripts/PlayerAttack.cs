using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    public int attackPower = 1;

    //EnemyStatus enemyStatus;         // 敵のステータス
    private GameObject enemy;   // 敵となるオブジェクト

    //オブジェクトと接触した瞬間に呼び出される
    void OnTriggerEnter(Collider other)
    {
        

        //攻撃した相手がEnemyの場合
        if (other.CompareTag("Enemy"))
        {
            var targetEnemyStatus = other.GetComponent<EnemyStatus>();
            targetEnemyStatus.Damage(attackPower);
          //  Debug.Log("HPだよ");

        }

        //仮　　Blockタグが付いたオブジェクトを消す
        if (other.CompareTag("Block"))
        {
            Destroy(other.gameObject);

        }
    }
}

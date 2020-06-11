using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int damage;          // ヒットした時のダメージ量
    private GameObject enemy;   // 敵となるオブジェクト
    private Status status;      // オブジェクトが所持しているHPクラス

    void Start()
    {
        enemy = this.gameObject;
        status = enemy.GetComponent<Status>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Attack")
        {
            Debug.Log("ダメージだよ");
            // HPクラスのDamage関数を呼ぶ
            status.Damage(damage);

            // 攻撃オブジェクトを消去
            // Destroy(other.gameObject);
        }

    }
}

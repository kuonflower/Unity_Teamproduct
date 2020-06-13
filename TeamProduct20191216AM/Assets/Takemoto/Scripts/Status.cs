using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int hitPoint;  // HP

    public int minHitPoint = 1;
    public int maxHitPoint = 4;

    public GameObject damageBurst;
    public float destroyTime;

    private void Start()
    {
        hitPoint = Random.Range(minHitPoint, maxHitPoint);
    }

    // Update is called once per frame
    void Update()
    {

        //HPが0になったときに自身を破壊する
        if (hitPoint <= 0)
        {          
            //GenerateEffect();
            Destroy(gameObject, 3f);
        }

    }

    //ダメージを受け取ってHPを減らす関数
    public void Damage(int damage)
    {       
        hitPoint -= damage;
    }

    //エフェクトを生成する
    public void GenerateEffect()
    {
        GameObject effect = Instantiate(damageBurst) as GameObject;
        effect.transform.position = gameObject.transform.position;
        Destroy(effect, destroyTime);

    }
}

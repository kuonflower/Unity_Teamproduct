using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPlayer : MonoBehaviour
{
    public static int hitPoint = 1;  // HP
    Animator animator;


    // public GameObject damageBurst;
    public float destroyTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
        Debug.Log(this.gameObject + "のダメージ受けた後のHP：" + hitPoint);
        if (hitPoint >= 1)
        {
            animator.SetTrigger("Damage");
        }
        else
        {
            animator.SetBool("Die", true);
        }
    }

    //エフェクトを生成する
    //public void GenerateEffect()
    //{
    //    GameObject effect = Instantiate(damageBurst) as GameObject;
    //    effect.transform.position = gameObject.transform.position;
    //    Destroy(effect, destroyTime);

    //}
}

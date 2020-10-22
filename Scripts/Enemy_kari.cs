using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//NavMeshagentを使うために記述

public class Enemy_kari : MonoBehaviour

{
    public Vector3[] wayPoints = new Vector3[3];//徘徊するポイントをの座標を代入するVector3型の変数の配列を作る
    private int currentRoot = 0;//現在目指すポイントを代入する変数
    private int Mode;//敵の行動パターンを分けるための変数
    public Transform player;//プレイヤーの位置を取得するためのTransform型変数
    public Transform enemypos;//敵の位置を取得するためのTransform型の変数
    private NavMeshAgent agent;//NavMeshAgentの情報を取得するためのNavMeshAgent 型の変数



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();//NavMeshAgentの情報をagentに代入
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = wayPoints[currentRoot];//Vector3型のposに現在の目的地座標を代入
        float distance = Vector3.Distance(enemypos.position, player.transform.position);//敵とプレイヤーの距離を求める

        if (distance > 5)//もしプレイヤーと敵の距離が５より大きいなら
        {
            Mode = 0;//Modeを0にする
            Debug.Log(currentRoot);
        }

        if (distance < 5)//もしプレイヤーとの距離が5より小さいなら
        {
            Mode = 1;
        }

        switch (Mode)
        {
            case 0:
                //もし敵の位置と現在の目的地が1よりちいさいなら
                if (Vector3.Distance(transform.position, pos) < 1f)
                {
                   // Debug.Log("case0");
                    currentRoot += 1;
                    if (currentRoot > wayPoints.Length - 1)//もしcurrentRootがwayPointsの要素数-1より大きいなら
                    {
                        currentRoot = 0;//currentRootを0にする
                    }
                }
                GetComponent<NavMeshAgent>().SetDestination(pos);//NavMeshAgentの情報を取得し目的地をposにする
                //Debug.Log(pos);
                break;
            case 1:
                agent.destination = player.transform.position;//プレイヤーに向かって進む

               // Debug.Log("case1");
                break;
        }

    }
}

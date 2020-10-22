using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyStatus))]
public class EnemyMove : MonoBehaviour
{

    [SerializeField] private LayerMask raycastLayerMask; //レイヤーマスク
    [SerializeField] private PlayerController playerController;

    private NavMeshAgent _agent;
    private RaycastHit[] _raycastHits = new RaycastHit[10];

    private EnemyStatus _status;

    public GameObject player;

    private bool approachFlag = false;



    public Vector3[] wayPoints = new Vector3[3];//徘徊するポイントをの座標を代入するVector3型の変数の配列を作る
    private int currentRoot = 0;//現在目指すポイントを代入する変数
   // private int Mode;//敵の行動パターンを分けるための変数
   // public Transform player;//プレイヤーの位置を取得するためのTransform型変数
    public Transform enemypos;//敵の位置を取得するためのTransform型の変数
    private NavMeshAgent agent;//NavMeshAgentの情報を取得するためのNavMeshAgent 型の変数



    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _status = GetComponent<EnemyStatus>();
    }

    public void OnDetectObject(Collider collider)
    {
       // Debug.Log(collider);
        if (!_status.IsMovable)
        {
            _agent.isStopped = true;
            return;
        }

        //検知したオブジェクトに「Player」tagが付いてたらそのオブジェクトを追いかける
        if (collider.CompareTag("Player"))
        {

            //var positionDiff = collider.transform.position - transform.position;
            //var distance = positionDiff.magnitude;

            //var direction = positionDiff.normalized;// playerへの方向

            //// _raycastHitsにヒットしたColliderや座標情報などが格納される
            ////RaycastAllとRaycastNonAllocは同等の機能だが、RaycastNonAllocだとメモリにごみが残らないのでこちらを推奨

            //var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits, distance,raycastLayerMask);

            //Debug.Log("hitCount:" + hitCount);
            //if(hitCount == 0)
            //{

            //    //　仮　本作のプレイヤーはCharacterControllerを使っていて、Colliderは使っていないのでRaycastはヒットしない
            //    //　ヒット数が0であればプレイヤーとの間に障害物がないということになる
            //    _agent.isStopped = false;
            //}
            //else
            //{
            //    //見失ったら停止する
            //    _agent.isStopped = true;
            //}
            approachFlag = true;
            _agent.destination = collider.transform.position;
            _agent.isStopped = false;
        }
    }

    public void OffDetectObject(Collider collider)
    {
        approachFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = wayPoints[currentRoot];//Vector3型のposに現在の目的地座標を代入
       // Debug.Log(approachFlag);
        if (!approachFlag)
        {
            //もし敵の位置と現在の目的地が1よりちいさいなら
            if (Vector3.Distance(transform.position, pos) < 1.5f)
            {
               
                currentRoot += 1;
                if (currentRoot > wayPoints.Length - 1)//もしcurrentRootがwayPointsの要素数-1より大きいなら
                {
                    currentRoot = 0;//currentRootを0にする
                }
            }
            GetComponent<NavMeshAgent>().SetDestination(pos);//NavMeshAgentの情報を取得し目的地をposにする
           // Debug.Log(pos);
            //_agent.destination = this.transform.position;
            // _agent.destination = player.transform.position;
        }
    }
}

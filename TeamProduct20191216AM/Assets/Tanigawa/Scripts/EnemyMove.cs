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

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _status = GetComponent<EnemyStatus>();
    }

    public void OnDetectObject(Collider collider)
    {
        if (!_status.IsMovable)
        {
            _agent.isStopped = true;
            return;
        }

        //検知したオブジェクトに「Player」tagが付いてたらそのオブジェクトを追いかける
        if (collider.CompareTag("Player"))
        {

            var positionDiff = collider.transform.position - transform.position;
            var distance = positionDiff.magnitude;

            var direction = positionDiff.normalized;// playerへの方向

            // _raycastHitsにヒットしたColliderや座標情報などが格納される
            //RaycastAllとRaycastNonAllocは同等の機能だが、RaycastNonAllocだとメモリにごみが残らないのでこちらを推奨

            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits, distance,raycastLayerMask);

            Debug.Log("hitCount:" + hitCount);
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
            _agent.destination = collider.transform.position;
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    _agent.destination = player.transform.position;
    //}
}

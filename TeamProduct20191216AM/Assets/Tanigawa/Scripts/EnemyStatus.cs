using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyStatus : MobStatus
{

    private NavMeshAgent _agent;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        //NavMeshAgentのvelocityで移動速度のベクトルが取得できる
        _animator.SetFloat("MoveSpeed", _agent.velocity.magnitude);
    }

    protected override void OnDie()
    {
        base.OnDie();
        StartCoroutine(DestroyCoroutine());
    }

    //倒された時の消滅コルーチン
    //<returns></returns>
    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobStatus))]
public class MobAttack : MonoBehaviour
{

    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private Collider attackCollider;

    private MobStatus _status;

    // Start is called before the first frame update
    private void Start()
    {
        _status = GetComponent<MobStatus>();
    }

    //攻撃可能状態であれば攻撃を行います。
    public void AttackIfPossible()
    {
        if (!_status.IsAttackable) return;

        _status.GoToAttackStateIfPossible();
    }

    // <param name="collider"></param>
    public void OnAttackRangeEnter(Collider collider)
    {
        AttackIfPossible();
    }

    public void OnAttackStart()
    {
        attackCollider.enabled = true;
    }

    //attackColliderが攻撃対象にhitしたときに呼ばれます
    //<param name="collider"></collider>
    public void OnHitAttack(Collider collider)
    {
        //var targetMob = collider.GetComponent<MobStatus>();
        //if (null == targetMob) return;

        ////プレイヤーにダメージを与える
        //targetMob.Damage(1);

        var targetStatusPlayer = collider.GetComponent<StatusPlayer>();
        if (null == targetStatusPlayer) return;

        //プレイヤーにダメージを与える
        targetStatusPlayer.Damage(1);

    }

    //攻撃終了時に呼ばれます
    public void OnAttackFinished()
    {
        attackCollider.enabled = false;

        

        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        _status.GoToNormalStateIfPossible();

        //Debug.Log("CooldownCoroutine:" + _status.IsMovable + ":" + attackCooldown);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

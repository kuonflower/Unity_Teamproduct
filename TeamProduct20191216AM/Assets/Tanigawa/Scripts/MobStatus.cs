using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobStatus : MonoBehaviour
{

    protected enum StateEnum
    {
        Normal,
        Attack,
        Die
    }

    public bool IsMovable => StateEnum.Normal == _state;

    public bool IsAttackable => StateEnum.Normal == _state;

    public float LifeMax => lifeMax;

    public float Life => _life;

    [SerializeField] private float lifeMax = 10; //ライフ最大値
    protected Animator _animator;
    protected StateEnum _state = StateEnum.Normal; //Mob状態
    private float _life;

    // Start is called before the first frame update
    void Start()
    {
        _life = lifeMax; //初期はライフ満タン
        _animator = GetComponentInChildren<Animator>();
    }

    //キャラクターが倒れた時の処理を記述します
    protected virtual void OnDie()
    {

    }

    //指定地のダメージを受けます
    // <param name="damage"></pamam>
    public void Damage(int damage)
    {
        if (_state == StateEnum.Die) return;

        _life -= damage;
        if (_life > 0) return;

        _state = StateEnum.Die;
        _animator.SetTrigger("Die");

        OnDie();


    }

    //可能であれば攻撃中の状態に遷移します
    public void GoToAttackStateIfPossible()
    {
        if (!IsAttackable) return;

        _state = StateEnum.Attack;
        _animator.SetTrigger("Attack");
    }

    public void GoToNormalStateIfPossible()
    {
        if (_state == StateEnum.Die) return;

        _state = StateEnum.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject rightFoot;

    private Collider rightHandCollider;
    private Collider rightFootCollider;

    [SerializeField] GameObject rightHandAttackEffect;
    [SerializeField] GameObject rightFootAttackEffect;



    private void Start()
    {
        rightHandCollider = rightHand.GetComponent<SphereCollider>();
        rightFootCollider = rightFoot.GetComponent<SphereCollider>();

       

    }

    void HandAttackStart()
    {
        rightHandCollider.enabled = true;
        AudioManager.Instance.PlaySE("PlayerAttackSE1");
        rightHandAttackEffect.SetActive(true);
    }

    void HandAttackEnd()
    {
        rightHandCollider.enabled = false;
        rightHandAttackEffect.SetActive(false);
    }

    void FootAttackStart()
    {

        rightFootCollider.enabled = true;
        rightFootAttackEffect.SetActive(true);
        
        int randomAttackVoice;
        randomAttackVoice = Random.Range(1,4);
        AudioManager.Instance.PlaySE("PlayerAttackSE1");
        AudioManager.Instance.PlayVoice("AttackVoice" + randomAttackVoice);
       
    }

    void FootAttackEnd()
    {
        rightFootCollider.enabled = false;
        rightFootAttackEffect.SetActive(false);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject rightFoot;

    private Collider rightHandCollider;
    private Collider rightFootCollider;

    
        

    private void Start()
    {
        rightHandCollider = rightHand.GetComponent<SphereCollider>();
        rightFootCollider = rightFoot.GetComponent<SphereCollider>();
        
    }

    void HandAttackStart()
    {
        rightHandCollider.enabled = true;
    }

    void HandAttackEnd()
    {
        rightHandCollider.enabled = false;
    }

    void FootAttackStart()
    {
        rightFootCollider.enabled = true;
    }

    void FootAttackEnd()
    {
        rightFootCollider.enabled = false;
    }


}

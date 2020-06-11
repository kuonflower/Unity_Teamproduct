using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehavior : StateMachineBehaviour
{
   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Damage");
    }
 
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Damage");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : StateMachineBehaviour
{   
    FollowPlayer fp;
    Boss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fp = animator.GetComponent<FollowPlayer>();
        boss = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (boss.bossfight)
        {
            if (fp.distToPlayer < fp.agroRange - 20)
            {
                animator.SetBool("Idle", false);
                animator.SetBool("Attack", true);
            }
            else if (fp.distToPlayer > fp.agroRange)
            {
                animator.SetBool("Idle", true);
                animator.SetBool("Attack", false);
            }
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Attack", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attack", false);
        animator.SetBool("Idle", false);
    }
}

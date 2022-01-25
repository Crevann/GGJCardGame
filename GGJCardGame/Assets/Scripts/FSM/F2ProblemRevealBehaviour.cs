using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F2ProblemRevealBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        TurnLamps.Instance.TurnOnLamp(animator.GetInteger(MatchStats.Instance.currentTurnParam));
        animator.SetInteger(MatchStats.Instance.currentTurnParam, animator.GetInteger(MatchStats.Instance.currentTurnParam) + 1);
        MatchLogic.Instance.problemsDeck.Shuffle(); //Shuffle Problems deck
        Problem problemShown = MatchLogic.Instance.problemsDeck.Dequeque();
        
        int i = MatchStats.Instance.AddProblem(problemShown);
        problemShown.MoveTo(Vector3.Lerp(MatchStats.Instance.firstProblemPos.position, MatchStats.Instance.lastProblemPos.position, (float)i / MatchStats.Instance.maxProblems), false, true);
        animator.SetTrigger(MatchStats.Instance.finishedStateParam);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

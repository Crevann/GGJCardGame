using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneLoad : StateMachineBehaviour
{
    private ClockHand clockHand;
    private void Awake() {
        clockHand = GameObject.Find("UIPointer").GetComponent<ClockHand>();
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        PlayerStats.body = StaticLogic.body;
        PlayerStats.soul = StaticLogic.soul;
        clockHand.Rotate();
        GameLogic.Instance.currentMatch = StaticLogic.matchNumber;
        if (GameLogic.Instance.currentMatch < 3) {
            MatchStats.Instance.StartMatch(MatchStats.LevelDifficulty.easy);
        } else if (GameLogic.Instance.currentMatch < 5) {
            MatchStats.Instance.StartMatch(MatchStats.LevelDifficulty.medium);
        } else {
            MatchStats.Instance.StartMatch(MatchStats.LevelDifficulty.hard);
        }
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

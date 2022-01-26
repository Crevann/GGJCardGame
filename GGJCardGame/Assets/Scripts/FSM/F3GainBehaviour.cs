using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3GainBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        MatchStats.Instance.CurrentBodyIngots += MatchStats.Instance.CurrentMajorArcana.BodyIngotGain;
        MatchStats.Instance.CurrentSoulCoins += MatchStats.Instance.CurrentMajorArcana.SoulCoinGain;
        animator.SetTrigger(MatchStats.Instance.finishedStateParam);
        //TODO animation
    }
}

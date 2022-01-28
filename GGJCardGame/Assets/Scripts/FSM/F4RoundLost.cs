using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F4RoundLost : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameLogic.hasLost = true;
        MatchLogic.Instance.CleanTable();
        for (int i = 0; i < 5; i++) {
            TurnLamps.Instance.TurnOffLamp(i);
        }
        animator.SetTrigger(MatchStats.Instance.finishedStateParam);
    }
}

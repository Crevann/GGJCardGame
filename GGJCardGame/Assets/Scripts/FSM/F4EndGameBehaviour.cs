using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F4EndGameBehaviour : StateMachineBehaviour
{
    [SerializeField] private string winRoundParam = "WinRound";
    [SerializeField] private string loseRoundParam = "LoseRound";
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if(MatchStats.Instance.currentStability < -PlayerStats.Instance.StabilityRange 
            && MatchStats.Instance.currentStability > PlayerStats.Instance.StabilityRange) {
            animator.SetTrigger(loseRoundParam);
        }
        else {
            animator.SetTrigger(winRoundParam);
        }
    }
}

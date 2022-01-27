using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3VisualizeFeedback : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        ShowFeedback();

        if(animator.GetInteger(MatchStats.Instance.currentTurnParam) >= MatchStats.Instance.maxProblems) {
            animator.SetTrigger(MatchStats.Instance.endGameParam);
        }
        else {
            animator.SetTrigger(MatchStats.Instance.finishedStateParam);
        }
    }

    private void ShowFeedback() {
        float stability = (float)MatchStats.Instance.GetStability() / PlayerStats.Instance.StabilityRange;
        PostProcessMGR.Instance.StartVignetting(stability);
        
    }
    private void ShowFeedback(string feedback) {
        //TODO son le 4:51 ho sonno va fatto poi
    }

    
}

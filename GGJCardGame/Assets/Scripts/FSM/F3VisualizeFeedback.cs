using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3VisualizeFeedback : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        CalculateStability();
        animator.SetTrigger(MatchStats.Instance.finishedStateParam);
    }

    private void ShowFeedback(string feedback) {
        //TODO son le 4:51 ho sonno va fatto poi
    }

    private void CalculateStability() {
        int stability = 0;
        foreach (Minor minor in MatchStats.Instance.CurrentMinorsOnMajor) {
            stability += (int) minor.stabilityGain;
        }
        for (int i = 0; i < MatchStats.Instance.CurrentProblems.Length; i++) {
            if (MatchStats.Instance.CurrentProblems[i] != null) {
                stability += MatchStats.Instance.CurrentProblems[i].StabilityChange;
            }
        }
        MatchStats.Instance.currentStability = stability;
    }
}

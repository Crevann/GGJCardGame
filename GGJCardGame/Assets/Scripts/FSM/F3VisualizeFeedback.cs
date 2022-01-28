using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3VisualizeFeedback : StateMachineBehaviour
{
    [SerializeField] private float feedbackTime;
    private float currentFeedbackTime;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        ShowFeedback("When your mind is as scrambled as it just was, it feels like a rollercoaster ride! Can't wait for the next ride!");
        currentFeedbackTime = feedbackTime;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        currentFeedbackTime -= Time.deltaTime;
        if(currentFeedbackTime <= 0) {
            NextState(animator);
        }
    }

    private void ShowFeedback(string feedback) {
        DescriptionPage.Instance.StringToWrite = feedback;
        float stability = (float)MatchStats.Instance.GetStability() / PlayerStats.Instance.StabilityRange;
        PostProcessMGR.Instance.StartVignetting(stability);
        
    }
    private void NextState(Animator animator) {
        DescriptionPage.Instance.GoDown();
        if (animator.GetInteger(MatchStats.Instance.currentTurnParam) >= MatchStats.Instance.maxProblems) {
            animator.SetTrigger(MatchStats.Instance.endGameParam);
        }
        else {
            animator.SetTrigger(MatchStats.Instance.finishedStateParam);
        }
    }
}

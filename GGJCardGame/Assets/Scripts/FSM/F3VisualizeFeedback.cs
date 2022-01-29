using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3VisualizeFeedback : StateMachineBehaviour
{
    [SerializeField] private float feedbackTime;
    private float currentStability;
    private float oldStability = 0;
    private float currentFeedbackTime;
    public ScriptableLifeSentences lifeSentences;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        currentStability = MatchStats.Instance.GetStability();
        currentFeedbackTime = feedbackTime;
        if (oldStability == currentStability) {
            ShowFeedback(lifeSentences.neutralSentences);
        }else if (oldStability <= 0) {
            if(currentStability < oldStability) {
                ShowFeedback(lifeSentences.moreDepressionSentences);
            }
            else {
                ShowFeedback(lifeSentences.lessDepressionSentences);
            }
        }else if (oldStability >= 0) {
            if (currentStability < oldStability) {
                ShowFeedback(lifeSentences.lessMadnessSentences);
            }
            else {
                ShowFeedback(lifeSentences.moreMadnessSentences);
            }
        }
        oldStability = currentStability;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        currentFeedbackTime -= Time.deltaTime;
        if(currentFeedbackTime <= 0 && currentFeedbackTime > -100) {
            currentFeedbackTime = -100;
            NextState(animator);
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        DescriptionPage.Instance.StringToWrite = null;
    }

    private void ShowFeedback(string[] feedback) {
        DescriptionPage.Instance.StringToWrite = feedback[Random.Range(0, feedback.Length)];
        float stability = (float)MatchStats.Instance.GetStability() / PlayerStats.Instance.StabilityRange;
        PostProcessMGR.Instance.StartVignetting(stability);
        
    }
    private void NextState(Animator animator) {
        DescriptionPage.Instance.StringToWrite = null;
        if (animator.GetInteger(MatchStats.Instance.currentTurnParam) >= MatchStats.Instance.MaxProblems) {
            animator.SetTrigger(MatchStats.Instance.endGameParam);
        }
        else {
            animator.SetTrigger(MatchStats.Instance.finishedStateParam);
        }
    }
}

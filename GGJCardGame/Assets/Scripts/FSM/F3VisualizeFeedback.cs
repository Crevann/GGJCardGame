using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3VisualizeFeedback : StateMachineBehaviour
{
    [SerializeField] private float feedbackTime;
<<<<<<< Updated upstream
    private float currentStability;
    private float oldStability = 0;
    private float currentFeedbackTime;
    public ScriptableLifeSentences lifeSentences;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        currentStability = MatchStats.Instance.GetStability();
=======
    [SerializeField] private List<string> negativeOnNegative; //getting depression
    [SerializeField] private List<string> positiveOnNegative; //recovering from depression
    [SerializeField] private List<string> negativeOnPositive; //recovering from madness
    [SerializeField] private List<string> positiveOnPositive; //getting madness
    [SerializeField] private List<string> neutral;

    [SerializeField] private float neutralRange = 3;
    private float currentFeedbackTime;
    private float stability;
    private float Stability => stability = (float)MatchStats.Instance.GetStability() / PlayerStats.Instance.StabilityRange;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (Stability > neutralRange) //player in madness field
        {
            if (MatchStats.Instance.GetStabilityGain() > 0) //player going mad
            {
                ShowRandomFeedbackFromList(positiveOnPositive);
            } else //player recovering
            {
                ShowRandomFeedbackFromList(negativeOnPositive);
            }
        }
        if (Stability < -neutralRange) //player in depression Range
        {
            if (MatchStats.Instance.GetStabilityGain() > 0) //player recovering
            {
                ShowRandomFeedbackFromList(positiveOnNegative);
            } else //player getting depressed
            {
                ShowRandomFeedbackFromList(negativeOnNegative);
            }
        } 
        if (stability >= -neutralRange && stability <= neutralRange)
        {
            ShowRandomFeedbackFromList(neutral);
        }
    }

    private void ShowRandomFeedbackFromList(List<string> list)
    {
        int random = Random.Range(0, list.Count);
        ShowFeedback(list[random]);
>>>>>>> Stashed changes
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
        if(currentFeedbackTime <= 0) {
            NextState(animator);
        }
    }

<<<<<<< Updated upstream
    private void ShowFeedback(string[] feedback) {
        DescriptionPage.Instance.StringToWrite = feedback[Random.Range(0, feedback.Length)];
        float stability = (float)MatchStats.Instance.GetStability() / PlayerStats.Instance.StabilityRange;
        PostProcessMGR.Instance.StartVignetting(stability);
=======
    private void ShowFeedback(string feedback) {
        DescriptionPage.Instance.StringToWrite = feedback;
        PostProcessMGR.Instance.StartVignetting(Stability);
>>>>>>> Stashed changes
        
    }
    private void NextState(Animator animator) {
        DescriptionPage.Instance.StringToWrite = null;
        if (animator.GetInteger(MatchStats.Instance.currentTurnParam) >= MatchStats.Instance.maxProblems) {
            animator.SetTrigger(MatchStats.Instance.endGameParam);
        }
        else {
            animator.SetTrigger(MatchStats.Instance.finishedStateParam);
        }
    }
}

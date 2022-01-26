using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F4RoundPassed : StateMachineBehaviour
{
    private ClockHand clockHand;
    private void Awake() {
        clockHand = GameObject.Find("UIPointer").GetComponent<ClockHand>();
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CalculateBodySoulLevel();
        clockHand.Rotate();
        if(animator.GetInteger(MatchStats.Instance.currentMatchParam) >= GameLogic.Instance.maxMatches) {
            animator.SetTrigger(MatchStats.Instance.endGameParam);
        }
        else {
            animator.SetTrigger(MatchStats.Instance.finishedStateParam);
        }
    }

    private void CalculateBodySoulLevel() {
        foreach (Minor minor in MatchStats.Instance.CurrentMinorsOnMajor) {
            PlayerStats.Instance.body += minor.Body;
            PlayerStats.Instance.soul += minor.Soul;
        }
    }
}

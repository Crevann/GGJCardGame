using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            MatchLogic.Instance.CleanTable();
            for (int i = 0; i < 5; i++) {
                TurnLamps.Instance.TurnOffLamp(i);
            }
            animator.SetTrigger(MatchStats.Instance.endGameParam);
        }
        else {
            animator.SetTrigger(MatchStats.Instance.finishedStateParam);
        }
    }

    private void CalculateBodySoulLevel() {
        foreach (Minor minor in MatchStats.Instance.CurrentMinorsOnMajor) {
            PlayerStats.body += minor.Body;
            PlayerStats.soul += minor.Soul;
        }
        StaticLogic.soul = PlayerStats.soul;
        StaticLogic.body = PlayerStats.body;
    }
}

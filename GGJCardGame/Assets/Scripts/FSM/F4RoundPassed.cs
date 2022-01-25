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
    }

    private void CalculateBodySoulLevel() {
        foreach (Minor minor in MatchStats.Instance.CurrentMinorsOnMajor) {
            PlayerStats.Instance.body += minor.Body;
            PlayerStats.Instance.soul += minor.Soul;
        }
    }
}

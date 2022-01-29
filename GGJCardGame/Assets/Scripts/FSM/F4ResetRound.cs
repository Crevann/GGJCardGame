using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F4ResetRound : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        PostProcessMGR.Instance.StartVignetting(0);
        animator.SetInteger(MatchStats.Instance.currentTurnParam, 0);
        CleanTable();
        for (int i = 0; i < 5; i++) {
            TurnLamps.Instance.TurnOffLamp(i);
        }
        MatchLogic.Instance.majorDeck.outOfDeck.Clear();
        animator.SetTrigger(MatchStats.Instance.finishedStateParam);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        MatchStats.Instance.StartMatch(MatchStats.LevelDifficulty.easy);
    }

    private void CleanTable() {
        foreach (Minor minor in MatchStats.Instance.CurrentMinorArcanaHand) {
            if (minor == null) continue;
            minor.MoveTo(MatchLogic.Instance.minorDeck.transform.position, true);
        }
        foreach (Minor minor in MatchStats.Instance.CurrentMinorsOnMajor) {
            minor.ResetCard();
            minor.MoveTo(MatchLogic.Instance.minorDeck.transform.position, true);
        }
        foreach (Problem problem in MatchStats.Instance.CurrentProblems) {
            problem.MoveTo(MatchLogic.Instance.problemsDeck.transform.position, true);
        }
        MatchStats.Instance.CurrentMajorArcana.MoveTo(MatchStats.Instance.majorDeckPos.position, true);
    }
}

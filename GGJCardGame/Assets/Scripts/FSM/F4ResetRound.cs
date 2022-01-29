using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F4ResetRound : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        PostProcessMGR.Instance.StartVignetting(0);
        animator.SetInteger(MatchStats.Instance.currentTurnParam, 0);
        MatchLogic.Instance.CleanTable();
        for (int i = 0; i < 5; i++) {
            TurnLamps.Instance.TurnOffLamp(i);
        }
        MatchLogic.Instance.majorDeck.outOfDeck.Clear();
        animator.SetTrigger(MatchStats.Instance.finishedStateParam);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        GameLogic.Instance.currentMatch++;
        StaticLogic.matchNumber = GameLogic.Instance.currentMatch;
        if (GameLogic.Instance.currentMatch <= 2) {
            MatchStats.Instance.StartMatch(MatchStats.LevelDifficulty.easy);
        }else if(GameLogic.Instance.currentMatch < 5) {
            MatchStats.Instance.StartMatch(MatchStats.LevelDifficulty.medium);
        }
        else {
            MatchStats.Instance.StartMatch(MatchStats.LevelDifficulty.hard);
        }
    }
}

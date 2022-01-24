using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3MinorArcanaChoiceBehaviour : StateMachineBehaviour
{
    [SerializeField] int minorsNShown = 3;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        Minor[] shownedMinors = new Minor[minorsNShown];
        for (int i = 0; i < minorsNShown; i++) {
            shownedMinors[i] = MatchLogic.Instance.minorDeck.Dequeque();
            shownedMinors[i].InGame();
            shownedMinors[i].gameObject.SetActive(true);
            MatchStats.Instance.AddMinorCardToHand(shownedMinors[i]);
        }
    }

    public void EndTurn(Animator animator) {
        animator.SetTrigger(MatchStats.Instance.finishedStateParam);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1MajorArcanaChoiceBehaviour : StateMachineBehaviour
{
    [SerializeField] int majoursNShown = 3;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //Shuffle Major deck (also includes rotarion of the card)
        MatchLogic.Instance.majorDeck.Shuffle();
        MatchLogic.Instance.minorDeck.Shuffle();
        Major[] shownMajors = new Major[majoursNShown];
        for (int i = 0; i < majoursNShown; i++) {
            shownMajors[i] = MatchLogic.Instance.majorDeck.Dequeque();
            shownMajors[i].InGame();
        }
        MatchStats.Instance.shownMajorF1 = shownMajors;
    }
}

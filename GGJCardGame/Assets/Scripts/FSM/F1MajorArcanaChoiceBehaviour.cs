using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1MajorArcanaChoiceBehaviour : StateMachineBehaviour
{
    [SerializeField] int majoursNShown = 3;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetInteger(MatchStats.Instance.currentMatchParam, animator.GetInteger(MatchStats.Instance.currentMatchParam) + 1);
        //Shuffle Major deck (also includes rotarion of the card)
        MatchLogic.Instance.majorDeck.Shuffle();
        MatchLogic.Instance.minorDeck.Shuffle();
        Major[] shownMajors = new Major[majoursNShown];
        for (int i = 0; i < majoursNShown; i++) {
            shownMajors[i] = MatchLogic.Instance.majorDeck.Dequeque();
            shownMajors[i].gameObject.SetActive(true);
            shownMajors[i].SetRotation();
            //shownMajors[i].InGame();
        }
        MatchStats.Instance.ShownMajorF1 = shownMajors;
    }
}

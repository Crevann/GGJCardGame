using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class F3MinorArcanaChoiceBehaviour : StateMachineBehaviour
{
    [SerializeField] int minorsNShown = 3;
    private Animator animator;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        MatchStats.Instance.button.gameObject.SetActive(true);
        Minor[] shownedMinors = new Minor[minorsNShown];
        for (int i = MatchStats.Instance.CurrentMinorArcanaInHand(); i < minorsNShown; i++) {
            shownedMinors[i] = MatchLogic.Instance.minorDeck.Dequeque();
            shownedMinors[i].InGame();
            shownedMinors[i].gameObject.SetActive(true);
            MatchStats.Instance.AddMinorCardToHand(shownedMinors[i]);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        MatchStats.Instance.button.gameObject.SetActive(false);
    }
}

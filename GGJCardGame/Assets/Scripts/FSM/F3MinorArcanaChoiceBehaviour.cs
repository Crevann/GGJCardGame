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
        Minor[] shownedMinors = new Minor[minorsNShown];
        for (int i = CurrentNOfMinorsInHand(MatchStats.Instance.CurrentMinorArcanaHand); i < minorsNShown; i++) {
            shownedMinors[i] = MatchLogic.Instance.minorDeck.Dequeque();
            shownedMinors[i].InGame();
            shownedMinors[i].gameObject.SetActive(true);
            MatchStats.Instance.AddMinorCardToHand(shownedMinors[i]);
        }
    }
    private int CurrentNOfMinorsInHand(Minor[] array) {
        int n = 0;
        for (int i = 0; i < array.Length; i++) {
            if (array[i] != null) n++;
        }
        return n;
    }
}

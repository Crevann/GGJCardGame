using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Major {
    public void InGame() { }
}
public class F1MajorArcanaChoiceBehaviour : StateMachineBehaviour
{
    [SerializeField] int majoursNShown = 3;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //Shuffle Major deck (also includes rotarion of the card)
        Queue<Major> majors = new Queue<Major>(); //TODO Get the actual queue of Majours
        Major[] shownMajors = new Major[majoursNShown];
        for (int i = 0; i < majoursNShown; i++) {
            shownMajors[i] = majors.Dequeue();
            shownMajors[i].InGame();
        }
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

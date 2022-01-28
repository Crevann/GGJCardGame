using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBehaviour : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (FadeToBlack()) {
            SceneManager.LoadScene("EndScene");
        }
    }

    //Returns true if done
    private bool FadeToBlack() { //TODO Fade to black
        return true;
    }
}

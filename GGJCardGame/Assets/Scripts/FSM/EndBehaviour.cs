using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBehaviour : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (PostProcessMGR.Instance.FadeToBlack(true)) {
            SceneManager.LoadScene("EndScene");
        }
    }
}

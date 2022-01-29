using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndLogic : MonoBehaviour
{
    [Tooltip("0: neutral\n1: body\n2: soul\n3: game over")]
    [SerializeField] private string[] lifeEndings;
    [SerializeField] private TextMeshPro text;
    [SerializeField] private float neutralRange = 2;

    private void Awake() {
        int totalScore = Mathf.Clamp(-PlayerStats.soul + PlayerStats.body + 6, 0, 12);
        if (GameLogic.hasLost) {
            text.text = lifeEndings[3];
        }
        else {
            if (totalScore < 6 - neutralRange) {
                text.text = lifeEndings[2];
            }
            else if (totalScore > 6 + neutralRange) {
                text.text = lifeEndings[1];
            }
            else {
                text.text = lifeEndings[0];
            }
        }
    }

    private void Update() {
        PostProcessMGR.Instance.FadeToBlack(false);
    }
}

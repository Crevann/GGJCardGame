using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class Major : Card {
    string cardName;
    int getMinors = 3;
    int soulCoinGain;
    int bodyIngotGain;
    int reverceSoulCoinGain, reverseBodyIngotGain;
    string[] descriptionArray, flippedDescriptionArray;
    
    
   
    Sprite cardFace {
        set {
            GetComponent<SpriteRenderer>().sprite = value;
        }
    }
    public ScriptableMajor majorData {
        set {
            cardName = value.cardName;
            name = value.cardName + "(Major)";
            soulCoinGain = value.soulCoinGain;
            bodyIngotGain = value.bodyIngotGain;
            reverceSoulCoinGain = value.reverceSoulCoinGain;
            reverseBodyIngotGain = value.reverseBodyIngotGain;
            descriptionArray = value.descriptionArray;
            flippedDescriptionArray = value.flippedDescriptionArray;
            cardFace = value.cardFace;
        }
    }
    public int SoulCoinGain {
        get { return soulCoinGain; }
    }

    public int BodyIngotGain {
        get { return bodyIngotGain; }
    }
    private void OnMouseDown() {
        if (MatchStats.Instance.animator.GetCurrentAnimatorStateInfo(0).IsName("Fase 1")) {
            if (targetPos == transform.position) {
                MatchStats.Instance.CurrentMajorArcana = this;
                Minor[] shownedMinors = new Minor[getMinors];
                for (int i = 0; i < getMinors; i++) {
                    shownedMinors[i] = MatchLogic.Instance.minorDeck.Dequeque();
                    shownedMinors[i].InGame();
                    shownedMinors[i].gameObject.SetActive(true);
                    //MatchStats.Instance.AddMinorCardToHand(shownedMinors[i]);
                }
            }
        }
    }
}

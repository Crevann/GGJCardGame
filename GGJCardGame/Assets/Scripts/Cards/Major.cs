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
    [HideInInspector] public bool reverce;
    
    
   
    Sprite cardFace {
        set {
            GetComponent<SpriteRenderer>().sprite = value;
        }
    }
    public override void Start() {
        base.Start();
        if (Random.Range(0, 2) == 0) {
            reverce = false;
            transform.rotation = new Quaternion(0, 0, 0, 1);
        } else {
            reverce = true;
            targetRot = new Quaternion(0, 0, 1, 0); //sottosopra
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
        get {
            if (!reverce) return soulCoinGain;
            else return reverceSoulCoinGain;
         }
    }

    public int BodyIngotGain {
        get {
            if (!reverce) return bodyIngotGain;
            else return reverseBodyIngotGain;
        }
    }
    private void OnMouseDown() {
        if (MatchStats.Instance.animator.GetCurrentAnimatorStateInfo(0).IsName("Fase 1") && !MatchStats.Instance.IsPaused) {
            if (targetPos == transform.position) {
                
                MatchStats.Instance.CurrentMajorArcana = this;
            }
        }
    }
}

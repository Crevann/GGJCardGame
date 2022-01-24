using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class Major : Card {
    string cardName;
    int soulCoinGain;
    int bodyIngotGain;
    int reverceSoulCoinGain, reverseBodyIngotGain;
    string[] descriptionArray, flippedDescriptionArray;
    Vector3 targetPos;
    [HideInInspector] public float movementSpeed;
    bool thenDisable;
    Sprite cardFace {
        set {
            GetComponent<SpriteRenderer>().sprite = value;
        }
    }
    public ScriptableMajor majorData {
        set {
            cardName = value.cardName;
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
    public void MoveTo(Vector3 pos, bool thenDisable = false) {
        this.thenDisable = thenDisable;
        targetPos = pos;
        //TODO animation
    }
    private void OnMouseDown() {
        if (targetPos == transform.position) {
            MatchStats.Instance.CurrentMajorArcana = this;
        }
    }
    void Start() {
        targetPos = transform.position;
    }

    void Update() {
        if (targetPos != transform.position) transform.position = Vector3.Lerp(transform.position, targetPos, movementSpeed * Time.deltaTime);
        else if (thenDisable) gameObject.SetActive(false);
    }
}

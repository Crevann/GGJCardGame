using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Minor : Card {
    string cardName;
    int soulCoinsCost;
    int bodyIngotCost;
    int soul, body;
    public float stabilityGain = Mathf.Infinity;
    Sprite cardFace {
        set {
            GetComponent<SpriteRenderer>().sprite = value;
        }
    }
    public ScriptableMinor minorData {
        set {
            cardName = value.cardName;
            name = value.cardName + "(Minor)";
            soulCoinsCost = value.soulCoinsCost;
            bodyIngotCost = value.bodyIngotCost;
            soul = value.soul == 0 ? soulCoinsCost : value.soul;
            body = value.body == 0 ? bodyIngotCost : value.body;
            stabilityGain = value.stabilityGain != Mathf.Infinity ? value.stabilityGain : (soulCoinsCost >= bodyIngotCost ? soulCoinsCost : bodyIngotCost);
            cardFace = value.cardFace;
        }
    }

    public int SoulCoinsCost
    {
        get { return soulCoinsCost; }
    }
    public int BodyIngotCost
    {
        get { return bodyIngotCost; }
    }
    
    public int Soul
    {
        get { return soul; }
    }

    public int Body
    {
        get
        {
            return body;
        }
    }

    
    public override void Start() {
        base.Start();
        if (stabilityGain == Mathf.Infinity) {
            if (soul > body) stabilityGain = soul;
            else stabilityGain = body;
        }
    }


    public override void Update() {
        base.Update();
        if (CheckCostCard()) {

        }
        
    }


    public override void InGame()
    {
       
    }

    public void PlayCard()
    {
        MatchStats.Instance.currentBodyIngots -= bodyIngotCost;
        MatchStats.Instance.currentSoulCoins -= soulCoinsCost;
        MatchStats.Instance.AddCardToMajor(this);
    }

    public bool CheckCostCard()
    {
        return MatchStats.Instance.currentBodyIngots >= bodyIngotCost && MatchStats.Instance.currentSoulCoins >= soulCoinsCost;
        
    }




    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && CheckCostCard())
        {
            if (MatchStats.Instance.animator.GetCurrentAnimatorStateInfo(0).IsName("Fase 3 minor choice")){
                PlayCard();
            }
        }
    }
}

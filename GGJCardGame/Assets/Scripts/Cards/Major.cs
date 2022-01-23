using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Major : Card
{
    int soulCoinGain;
    int bodyIngotGain;

    //public ScriptableMajor minorData {
    //    set {
    //        cardName = value.cardName;
    //        soulCoinsCost = value.soulCoinsCost;
    //        bodyIngotCost = value.bodyIngotCost;
    //        soul = value.soul == 0 ? soulCoinsCost : value.soul;
    //        body = value.body == 0 ? bodyIngotCost : value.body;
    //        stabilityGain = value.stabilityGain != Mathf.Infinity ? value.stabilityGain : (soulCoinsCost >= bodyIngotCost ? soulCoinsCost : bodyIngotCost);
    //        cardFace = value.cardFace;
    //    }
    //}
    public int SoulCoinGain
    {
        get { return soulCoinGain;}
    }

    public int BodyIngotGain
    {
        get { return bodyIngotGain;}
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

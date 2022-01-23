using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LightProbeProxyVolume))]
public class Minor : Card {
    int soulCoinsCost;
    int bodyIngotCost;
    int soul, body;
    [SerializeField] ScriptableMinor minorData;

    LightProbeProxyVolume bloomEffect;
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

    public float stabilityGain = Mathf.Infinity;
    public void Start() {
        if (stabilityGain == Mathf.Infinity) {
            if (soul > body) stabilityGain = soul;
            else stabilityGain = body;
        }
        bloomEffect = GetComponent<LightProbeProxyVolume>();
    }

    void Update()
    {
        if (CheckCostCard())
        {
            bloomEffect.enabled= true;
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
        if (Input.GetMouseButtonDown(0)&& CheckCostCard())
        {
            PlayCard();

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minor : Card
{
    int soulCoinsCost;
    int bodyIngotCost;
    int soul, body;

    public int SoulCoinsCost
    {
        get { return soulCoinsCost; }
    }
    public int BodyIngotCost
    {
        get { return bodyIngotCost; }
    }
    //TODO proprietà soulo body
    public float stabilityGain = Mathf.Infinity;
    public void Start() {
        if (stabilityGain == Mathf.Infinity) {
            if (soul > body) stabilityGain = soul;
            else stabilityGain = body;
        }
    }

    void Update()
    {
        
    }


    public override void PlayCard()
    {
        // TODO controllare che i soldi bastano per giocare la carta e magari aggiungere una linea di dialogo alla vita che ti dice che non hai abbasntanza soldi
    }
}

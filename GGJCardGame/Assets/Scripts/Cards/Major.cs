using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Major : Card
{
    int soulCoinGain;
    int bodyIngotGain;
    [SerializeField] ScriptableMajor obj;
    
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

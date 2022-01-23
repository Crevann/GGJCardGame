using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class Problem : Card
{
    string cardName;
    int stabilityChange;
    string description;
    Sprite cardFace {
        set {
            GetComponent<SpriteRenderer>().sprite = value;
        }
    }
    public ScriptableProblems problemsData {
        set {
            cardName = value.cardName;
            stabilityChange = value.stabilityChange;
            description = value.description;
            cardFace = value.cardFace;
        }
    }
    public int StabilityChange
    {
        get { return stabilityChange;}
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorDeck : Deck<Major>
{
    [SerializeField] ScriptableMajor[] minorsToCreate;
    [SerializeField] Major minorCardPrefab;
    public override void Start() {
        deck = new Major[minorsToCreate.Length];
        for (int i = 0; i < minorsToCreate.Length; i++) {
            deck[0] = Instantiate(minorCardPrefab);
            //deck[0].minorData = minorsToCreate[0];
        }
        base.Start();
    }
}

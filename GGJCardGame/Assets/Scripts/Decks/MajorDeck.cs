using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorDeck : Deck<Major>
{
    [SerializeField] ScriptableMajor[] majoursToCreate;
    [SerializeField] Major minorCardPrefab;
    public override void Start() {
        deck = new Major[majoursToCreate.Length];
        for (int i = 0; i < majoursToCreate.Length; i++) {
            deck[0] = Instantiate(minorCardPrefab);
            deck[0].majorData = majoursToCreate[0];
        }
        base.Start();
    }
}

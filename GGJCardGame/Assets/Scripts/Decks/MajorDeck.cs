using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorDeck : Deck<Major>
{
    [SerializeField] ScriptableMajor[] majoursToCreate;
    [SerializeField] Major majorCardPrefab;
    public override void Start() {
        deck = new Major[majoursToCreate.Length];
        for (int i = 0; i < majoursToCreate.Length; i++) {
            deck[i] = Instantiate(majorCardPrefab, transform);
            deck[i].transform.position = MatchStats.Instance.majorDeckPos.position;
            deck[i].majorData = majoursToCreate[i];
            deck[i].transform.position = transform.position;
        }
        base.Start();
    }
}

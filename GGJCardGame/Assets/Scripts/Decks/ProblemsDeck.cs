using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemsDeck : Deck<Problem>
{
    [SerializeField] ScriptableProblems[] problemsToCreate;
    [SerializeField] int[] cardsOfRound1, cardsOfRound2, cardsOfRound3, cardsOfRound4, cardsOfRound5;
    [SerializeField] Problem originalPrefab;
    public override void Start() {
        deck = new Problem[problemsToCreate.Length];
        for (int i = 0; i < problemsToCreate.Length; i++) {
            deck[i] = Instantiate(originalPrefab, transform);
            deck[i].transform.position = MatchStats.Instance.problemDeckPos.position;
            deck[i].problemsData = problemsToCreate[i];
            deck[i].transform.position = transform.position;
            deck[i].gameObject.SetActive(false);
        }
        base.Start();
    }
    public override void RestoreOriginalDeck() {
        List<Problem> newArray = new List<Problem>();
        int[] newIntArray;
        switch (GameLogic.Instance.currentMatch) {
            case 1:
                newIntArray = cardsOfRound1;
                break;
            case 2:
                newIntArray = cardsOfRound2;
                break;
            case 3:
                newIntArray = cardsOfRound3;
                break;
            case 4:
                newIntArray = cardsOfRound4;
                break;
            case 5:
                newIntArray = cardsOfRound5;
                break;
            default:
                newIntArray = cardsOfRound5;
                break;
        }
        
        for (int i = 0; i < newIntArray.Length; i++) {
            newArray.Add(deck[newIntArray[i]]);
        }
        SetCurrentDeck(newArray.ToArray());
    }
}

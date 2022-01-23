using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck<CardType> : MonoBehaviour{
    protected CardType[] deck;
    [SerializeField] 
    [HideInInspector] public Queue<CardType> currentDeck = new Queue<CardType>();
    private CardType tempGO;
    private List<CardType> outOfDeck = new List<CardType>();
    public virtual void Start() {
        RestoreOriginalDeck();
    }
    public void Shuffle() {
        CardType[] tempCurrentDeck = currentDeck.ToArray();
        for (int i = 0; i < tempCurrentDeck.Length; i++) {
            int rnd = Random.Range(0, tempCurrentDeck.Length);
            tempGO = tempCurrentDeck[rnd];
            tempCurrentDeck[rnd] = tempCurrentDeck[i];
            tempCurrentDeck[i] = tempGO;
        }
        SetCurrentDeck(tempCurrentDeck);
    }
    public CardType Dequeque() {
        CardType removedCard = currentDeck.Dequeue();
        outOfDeck.Add(removedCard);
        return removedCard;
    }
    private void SetCurrentDeck(CardType[] d = null) {
        if (d == null) d = deck;
        currentDeck.Clear();
        for (int i = 0; i < d.Length; i++) {
            currentDeck.Enqueue(d[i]);
        }
    }
    public void RestoreOriginalDeck() {
        SetCurrentDeck();
    }
}

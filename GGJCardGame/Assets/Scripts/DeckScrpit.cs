using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScrpit : MonoBehaviour{
    [SerializeField] Card[] deck;
    [HideInInspector] public Queue<Card> currentDeck = new Queue<Card>();
    private Card tempGO;
    private List<Card> outOfDeck = new List<Card>();
    public void Start() {
        RestoreOriginalDeck();
    }
    public void Shuffle() {
        Card[] tempCurrentDeck = currentDeck.ToArray();
        for (int i = 0; i < tempCurrentDeck.Length; i++) {
            int rnd = Random.Range(0, tempCurrentDeck.Length);
            tempGO = tempCurrentDeck[rnd];
            tempCurrentDeck[rnd] = tempCurrentDeck[i];
            tempCurrentDeck[i] = tempGO;
        }
        SetCurrentDeck(tempCurrentDeck);
    }
    public Card Dequeque() {
        Card removedCard = currentDeck.Dequeue();
        outOfDeck.Add(removedCard);
        return removedCard;
    }
    private void SetCurrentDeck(Card[] d = null) {
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

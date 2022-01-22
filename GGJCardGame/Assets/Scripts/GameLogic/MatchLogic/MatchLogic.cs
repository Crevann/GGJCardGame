using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchLogic : MonoBehaviour
{
    [SerializeField] Deck deck;
    private Minor selectedCard;

    //When card is hovered over, show description
    public void SelectCard(Minor card) {
        selectedCard = card;
    }
    public void PlaySelectedCard() {
        selectedCard.PlayCard();
    }
    public void GetCardFromDeck() {
        Minor card = (Minor) deck.Dequeque();
        MatchStats.Instance.AddCardToHand(card);
    }
    public void ChooseMajorArcana(Major card) {
        MatchStats.Instance.SetMajorArcana(card);
    }
    public void StartTurn() {
        MatchStats.Instance.currentBodyIngots += MatchStats.Instance.currentMajorArcana.BodyIngotGain;
        MatchStats.Instance.currentSoulCoins += MatchStats.Instance.currentMajorArcana.SoulCoinGain;
    }
    public void EndTurn() {
        //TODO Go to next FSM state
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchLogic : MonoBehaviour
{
    private Minor selectedCard;

    //When card is hovered over, show description
    public void SelectCard(Minor card) {
        selectedCard = card;
    }
    public void PlaySelectedCard() {
        selectedCard.PlayCard();
    }
    public void GetCardFromDeck() {
        
    }
    public void ChooseMajorArcana() {

    }
    public void SkipTurn() {

    }
    public void EndTurn() {

    }
}

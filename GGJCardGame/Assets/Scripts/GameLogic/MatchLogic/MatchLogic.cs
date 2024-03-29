using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchLogic : MonoBehaviour
{
    //[SerializeField] Deck deck;
    [SerializeField] public MajorDeck majorDeck;
    [SerializeField] public MinorDeck minorDeck;
    [SerializeField] public ProblemsDeck problemsDeck;
    private Minor selectedCard;

    private static MatchLogic instance;
    public static MatchLogic Instance {
        get {
            return instance;
        }
    }

    private void Awake() {
        if(KeepAudio.instance != null) {
            Destroy(KeepAudio.instance.gameObject);
        }
        if (instance == null) {
            instance = this;
        }
    }
    //When card is hovered over, show description
    public void SelectCard(Minor card) {
        selectedCard = card;
    }
    public void PlaySelectedCard() {
        selectedCard.PlayCard();
    }
    public void GetCardFromDeck() {
        //Minor card = (Minor) deck.Dequeque();
        //MatchStats.Instance.AddCardToHand(card);
    }
    public void ChooseMajorArcana(Major card) {
        MatchStats.Instance.SetMajorArcana(card);
    }
    public void StartTurn() {
        MatchStats.Instance.CurrentBodyIngots += MatchStats.Instance.CurrentMajorArcana.BodyIngotGain;
        MatchStats.Instance.CurrentSoulCoins += MatchStats.Instance.CurrentMajorArcana.SoulCoinGain;
    }
    public void EndTurn() {
        MatchStats.Instance.animator.SetTrigger(MatchStats.Instance.finishedStateParam);
    }
    public void CleanTable() {
        foreach (Minor minor in MatchStats.Instance.CurrentMinorArcanaHand) {
            if (minor == null) continue;
            minor.MoveTo(minorDeck.transform.position, true);
        }
        foreach (Minor minor in MatchStats.Instance.CurrentMinorsOnMajor) {
            minor.ResetCard();
            minor.MoveTo(minorDeck.transform.position, true);
        }
        foreach (Problem problem in MatchStats.Instance.CurrentProblems) {
            problem.MoveTo(problemsDeck.transform.position, true);
        }
        DescriptionPage.Instance.StringToWrite = null;
        MatchStats.Instance.CurrentMajorArcana.MoveTo(MatchStats.Instance.majorDeckPos.position, true);
    }
}

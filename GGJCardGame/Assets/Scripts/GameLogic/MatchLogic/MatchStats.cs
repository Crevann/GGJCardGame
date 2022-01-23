using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStats : MonoBehaviour {
    public enum LevelDifficulty {
        easy,
        medium,
        hard
    }

    [SerializeField] private int maxProblems;
    public int currentStability;
    public int currentSoulCoins;
    public int currentBodyIngots;
    private LevelDifficulty difficulty;
    public Major currentMajorArcana;

    [HideInInspector] public Major[] shownMajorF1;
    [SerializeField] private Minor[] currentMinorArcanaHand;
    public Minor[] CurrentMinorArcanaHand { get { return currentMinorArcanaHand; } }
    private List<Minor> currentMinorsOnMajor;
    private Problem[] currentProblems;

    private static MatchStats instance;
    public static MatchStats Instance {
        get {
            return instance;
        }
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        currentMajorArcana = null;
        currentMinorArcanaHand = new Minor[PlayerStats.Instance.MaxCardHard];
        currentMinorsOnMajor = new List<Minor>();
        currentProblems = new Problem[maxProblems];
    }

    public void StartMatch(LevelDifficulty levelDifficulty) {
        difficulty = levelDifficulty;
        ResetStats();
    }

    public void ResetStats() {
        currentSoulCoins = 0;
        currentBodyIngots = 0;
        currentStability = 0;
        EmptyHands();
        EmptyCardsOnMajor();
    }

    public void EmptyHands() {
        currentMajorArcana = null;
        for (int i = 0; i < currentMinorArcanaHand.Length; i++) {
            currentMinorArcanaHand[i] = null; //TODO non deve andare a null ma rimettere le carte non usate nel mazzo originale
        }
    }
    public int GetProblemsStability() {
        int stability = 0;
        foreach (Problem p in currentProblems) {
            stability += p.StabilityChange;
        }
        return stability;
    }
    public int GetMinorStability() {
        int stability = 0;
        foreach (Minor m in currentMinorsOnMajor) {
            stability += (int)m.stabilityGain;
        }
        return stability;
    }

    public void EmptyProblems() {
        for (int i = 0; i < currentProblems.Length; i++) {
            currentProblems[i] = null;//TODO
        }
    }

    public void EmptyCardsOnMajor() {
        currentMinorsOnMajor.Clear();//TODO
    }

    public void SetMajorArcana(Major card) {
        currentMajorArcana = card;
    }

    public void AddCardToMajor(Minor card) {
        currentMinorsOnMajor.Add(card);
    } 

    public bool AddMinorCardToHand(Minor card) {
        for (int i = 0; i < currentMinorArcanaHand.Length; i++) {
            if(currentMinorArcanaHand[i] == null) {
                currentMinorArcanaHand[i] = card;
                return true;
            }
        }
        return false;
    }

    public bool AddProblem(Problem card) {
        for (int i = 0; i < currentProblems.Length; i++) {
            if (currentProblems[i] == null) {
                currentProblems[i] = card;
                return true;
            }
        }
        return false;
    }

    public int CurrentMinorArcanaInHand() {
        for (int i = 0; i < currentMinorArcanaHand.Length; i++) {
            if(currentMinorArcanaHand[i] == null) {
                return i;
            }
        }
        return currentMinorArcanaHand.Length;
    }
}

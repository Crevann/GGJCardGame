using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStats : MonoBehaviour
{
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
    private Major currentMajorArcana;
    private Minor[] currentMinorArcanaHand;
    private Problem[] currentProblems;

    private static MatchStats instance;
    public static MatchStats Instance {
        get {
            if (instance == null){
                instance = new MatchStats;
            }
            return instance;
        }
    }

    private void Awake() {
        currentMajorArcana = null;
        currentMinorArcanaHand = new Minor[1];
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
    }

    public void EmptyHands() {
        currentMajorArcana = null;
        for (int i = 0; i < currentMinorArcanaHand.Length; i++) {
            currentMinorArcanaHand[i] = null;
        }
    }

    public void EmptyProblems() {
        for (int i = 0; i < currentProblems.Length; i++) {
            currentProblems[i] = null;
        }
    }

    public void SetMajorArcana(Major card) {
        currentMajorArcana = card;
    }

    public bool AddCardToHand(Minor card) {
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
}

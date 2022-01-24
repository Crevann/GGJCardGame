using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class MatchStats : MonoBehaviour {
    public enum LevelDifficulty {
        easy,
        medium,
        hard
    }

    
    public int currentStability;
    public int currentSoulCoins = 0;
    public int currentBodyIngots = 0;
    private LevelDifficulty difficulty;

    [Header("ANIMATOR")]
    [SerializeField] Animator animator;
    [SerializeField] string choseMajorParam;
    

    [Header("SET MAJOR")]
    [SerializeField] Transform posCard1;
    [SerializeField] Transform posCard2, posCard3, majorArcanaPosition;
    Major currentMajorArcana;
    public Transform majorDeckPos;
    private Major[] shownMajorF1;
    public Major CurrentMajorArcana {
        set {
            currentMajorArcana = value;
            for (int i = 0; i < shownMajorF1.Length; i++) {
                if (currentMajorArcana == shownMajorF1[i]) shownMajorF1[i].MoveTo(majorArcanaPosition.position);
                else shownMajorF1[i].MoveTo(majorDeckPos.position, true);
            }
            if (animator) animator.SetTrigger(choseMajorParam);
        }
        get { return currentMajorArcana; }
    }
    
    [HideInInspector]
    public Major[] ShownMajorF1 {
        set {
            shownMajorF1 = value;
            shownMajorF1[0].MoveTo(posCard1.position);
            shownMajorF1[1].MoveTo(posCard2.position);
            shownMajorF1[2].MoveTo(posCard3.position);
            //shownMajorF1[0].transform.position = posCard1.position;
            //shownMajorF1[1].transform.position = posCard2.position;
            //shownMajorF1[2].transform.position = posCard3.position;
            //shownMajorF1[0].gameObject.SetActive(true);
            //shownMajorF1[1].gameObject.SetActive(true);
            //shownMajorF1[2].gameObject.SetActive(true);
        }
    }
    [Header("SET MINOR")]
    [SerializeField] private Minor[] currentMinorArcanaHand;
    public Minor[] CurrentMinorArcanaHand { get { return currentMinorArcanaHand; } }
    private List<Minor> currentMinorsOnMajor;

    [Header("SET PROBLEMS")]
    [Range(0, 5)] public int maxProblems;
    public Transform firstProblemPos, lastProblemPos;
    public Transform problemDeckPos;
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
            if (currentMinorArcanaHand[i] == null) {
                currentMinorArcanaHand[i] = card;
                return true;
            }
        }
        return false;
    }

    public int AddProblem(Problem card) {
        for (int i = 0; i < currentProblems.Length; i++) {
            if (currentProblems[i] == null) {
                currentProblems[i] = card;

                return i;
            }
        }
        return -1;
    }

    public int CurrentMinorArcanaInHand() {
        for (int i = 0; i < currentMinorArcanaHand.Length; i++) {
            if (currentMinorArcanaHand[i] == null) {
                return i;
            }
        }
        return currentMinorArcanaHand.Length;
    }
}

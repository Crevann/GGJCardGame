using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class MatchStats : MonoBehaviour {
    public enum LevelDifficulty {
        easy,
        medium,
        hard
    }

    
    public int currentStability;
    [SerializeField] FlipCardLogic soulCointIndicator;
    [SerializeField] FlipCardLogic bodyIngotIndicator;
    [SerializeField] private int currentSoulCoins = 0;
    public int CurrentSoulCoins {
        get { return currentSoulCoins; }
        set {
            currentSoulCoins = value;
            soulCointIndicator.ChangeDigit(currentSoulCoins);
        }
    }
    [SerializeField] public int currentBodyIngots = 0;
    public int CurrentBodyIngots {
        get { return currentBodyIngots; }
        set {
            currentBodyIngots = value;
            bodyIngotIndicator.ChangeDigit(currentBodyIngots);
        }
    }
    private LevelDifficulty difficulty;
    private bool isPaused = false;

    public bool IsPaused
    {
        get { return isPaused; }
        set { isPaused = value; }
    }

    [Header("ANIMATOR")]
    public Animator animator;
    public string choseMajorParam;
    public string finishedStateParam;
    public string currentTurnParam;
    public string currentMatchParam;
    public string endGameParam;
    public Button button;
    

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
    [SerializeField] private Transform startingMinorPosition;
    [SerializeField] private float spacing;
    [SerializeField] private float spacingTurns;
    public Minor[] CurrentMinorArcanaHand { get { return currentMinorArcanaHand; } }
    private List<Minor> currentMinorsOnMajor;
    public List<Minor> CurrentMinorsOnMajor { get { return currentMinorsOnMajor; } }

    [Header("SET PROBLEMS")]
    [Range(0, 5)] public int maxProblems;
    public Transform firstProblemPos, lastProblemPos;
    public Transform problemDeckPos;
    [SerializeField] private Problem[] currentProblems;
    public Problem[] CurrentProblems { get { return currentProblems; } }

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
        MatchLogic.Instance.majorDeck.RestoreOriginalDeck();
        MatchLogic.Instance.minorDeck.RestoreOriginalDeck();
        MatchLogic.Instance.problemsDeck.RestoreOriginalDeck();
    }

    public void ResetStats() {
        CurrentSoulCoins = 0;
        CurrentBodyIngots = 0;
        currentStability = 0;
        EmptyHands();
        EmptyCardsOnMajor();
        EmptyProblems();
    }

    public void EmptyHands() {
        currentMajorArcana.MoveTo(majorDeckPos.position);
        currentMajorArcana.gameObject.SetActive(false);
        currentMajorArcana = null;
        for (int i = 0; i < currentMinorArcanaHand.Length; i++) {
            currentMinorArcanaHand[i].transform.parent = MatchLogic.Instance.minorDeck.transform;
            currentMinorArcanaHand[i].gameObject.SetActive(false);
            currentMinorArcanaHand[i] = null;
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
            currentProblems[i].transform.parent = MatchLogic.Instance.problemsDeck.transform;
            currentProblems[i].gameObject.SetActive(false);
            currentProblems[i] = null;
        }
    }

    public void EmptyCardsOnMajor() {
        foreach (Minor minor in currentMinorsOnMajor) {
            minor.transform.parent = MatchLogic.Instance.minorDeck.transform;
            minor.gameObject.SetActive(false);
        }
        currentMinorsOnMajor.Clear();
    }

    public void SetMajorArcana(Major card) {
        currentMajorArcana = card;
    }

    public void AddCardToMajor(Minor card) {
        card.MoveTo(new Vector3(startingMinorPosition.position.x + (spacing * (currentMinorsOnMajor.Count - 1)) + (spacingTurns * (animator.GetInteger(currentTurnParam) - 1)), 
            startingMinorPosition.position.y, 
            0));
        card.transform.parent = currentMajorArcana.transform;
        RemoveMinorArcanaFromHand(card);
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
        int minorNum = 0;
        for (int i = 0; i < currentMinorArcanaHand.Length; i++) {
            if (currentMinorArcanaHand[i] != null) {
                minorNum++;
            }
        }
        return minorNum;
    }

    public Minor RemoveMinorArcanaFromHand(Minor card) {
        for (int i = 0; i < currentMinorArcanaHand.Length; i++) {
            if (currentMinorArcanaHand[i] == card) {
                Minor retMinor = currentMinorArcanaHand[i];
                currentMinorArcanaHand[i] = null;
                return retMinor;
            }
        }
        return null;
    }
}

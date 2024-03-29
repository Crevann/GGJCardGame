using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public int maxMatches;
    [HideInInspector] public int currentMatch = 0;
    [Header("LIFE FLAGS")]
    static public bool hasLost;

    private static GameLogic instance;
    public static GameLogic Instance { get { return instance; } }

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public int maxMatches;
    public int currentMatch = 0;//TODO
    [Header("LIFE FLAGS")]
    //Empty
    [Header("LIFE GOALS")]
    //Empty

    private static GameLogic instance;
    public static GameLogic Instance { get { return instance; } }

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
    }
}

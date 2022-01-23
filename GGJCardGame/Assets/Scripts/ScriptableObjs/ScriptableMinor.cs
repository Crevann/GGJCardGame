using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MinorScriptableObject", order = 1)]
public class ScriptableMinor : ScriptableObject
{
    public string cardName;
    public int soulCoinsCost;
    public int bodyIngotCost;
    
    [Tooltip("If left to 0 it will be automaticly set as soulCoinsCost")]
    public int soul;
    [Tooltip("If left to 0 it will be automaticly set as bodyIngotCost")]
    public int body;
    [Tooltip("If left to Infinity it will be automaticly set as the grater value between soulCoinsCost and bodyIngotCost")]
    public float stabilityGain = Mathf.Infinity;
    public Sprite cardFace;
}


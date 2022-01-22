using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MinorScriptableObject", order = 1)]
public class ScriptableMinor : ScriptableObject
{
    [SerializeField] string cardName;
    [SerializeField] int soulCoinsCost;
    [SerializeField] int bodyIngotCost;
    [SerializeField] int soul, body;
    public float stabilityGain = Mathf.Infinity;
    [SerializeField] Sprite cardFace;
}


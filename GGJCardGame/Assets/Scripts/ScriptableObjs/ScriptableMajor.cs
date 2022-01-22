using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MajorScriptableObject", order = 1)]
public class ScriptableMajor : ScriptableObject
{
    [SerializeField] string cardName;
    [SerializeField] int soulCoinGain, bodyIngotGain;
    [SerializeField] Sprite cardFace;
    [SerializeField] int reverceSoulCoinGain, reverseBodyIngotGain;
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LifeData", menuName = "ScriptableObjects/LifeScriptableSentences")]
public class ScriptableLifeSentences : ScriptableObject
{
    public string[] totalDepressionSentences;
    public string[] depressionSentences;
    public string[] neutralSentences;
    public string[] madnessSentences;
    public string[] totalMadnessSentences;
}

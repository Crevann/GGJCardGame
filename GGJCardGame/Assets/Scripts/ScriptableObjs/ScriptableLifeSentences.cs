using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LifeData", menuName = "ScriptableObjects/LifeScriptableSentences")]
public class ScriptableLifeSentences : ScriptableObject
{
    public string[] moreDepressionSentences;
    public string[] lessDepressionSentences;
    public string[] neutralSentences;
    public string[] lessMadnessSentences;
    public string[] moreMadnessSentences;
}

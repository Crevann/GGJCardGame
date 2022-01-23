using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ProblemScriptableObject", order = 1)]
public class ScriptableProblems : ScriptableObject
{
    public string cardName;
    public int stabilityChange;
    public string description;
    public Sprite cardFace;
}


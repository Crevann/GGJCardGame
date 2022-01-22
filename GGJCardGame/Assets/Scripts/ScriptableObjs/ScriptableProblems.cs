using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ProblemScriptableObject", order = 1)]
public class ScriptableProblems : ScriptableObject
{
    [SerializeField] string cardName;
    [SerializeField] int stabilityChange;
    [SerializeField] string description;
}


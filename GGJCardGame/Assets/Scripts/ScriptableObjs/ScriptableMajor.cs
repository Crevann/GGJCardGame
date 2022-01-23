using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MajorScriptableObject", order = 1)]
public class ScriptableMajor : ScriptableObject
{
    public string cardName;
    public int soulCoinGain, bodyIngotGain;
    public Sprite cardFace;
    public int reverceSoulCoinGain, reverseBodyIngotGain;
    [Tooltip("Description of every minor card: \n" +
        "0: Train\n" +
        "1: Party\n" +
        "2: Eat\n" +
        "3: Smoke\n" +
        "4: Cry\n" +
        "5: Pray\n" +
        "6: Volunteering\n" +
        "7: Adopt\n" +
        "8: Reorganize\n" +
        "9: Socialize\n" +
        "10: Caio\n" +
        "11: Creature\n"
        )]
    public string[] descriptionArray = new string[12];
    [Tooltip("Flipped Description of every minor card: \n" +
        "0: Train\n" +
        "1: Party\n" +
        "2: Eat\n" +
        "3: Smoke\n" +
        "4: Cry\n" +
        "5: Pray\n" +
        "6: Volunteering\n" +
        "7: Adopt\n" +
        "8: Reorganize\n" +
        "9: Socialize\n" +
        "10: Caio\n" +
        "11: Creature\n"
        )]
    public string[] flippedDescriptionArray = new string[12];
}


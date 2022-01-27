using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinorDeck : Deck<Minor>
{
    [SerializeField] ScriptableMinor[] minorsToCreate;
    [SerializeField] Minor minorCardPrefab;
    public override void Start() {
        deck = new Minor[minorsToCreate.Length];
        for (int i = 0; i < minorsToCreate.Length; i++) {
            deck[i] = Instantiate(minorCardPrefab);
            deck[i].minorData = minorsToCreate[i];
            deck[i].transform.SetParent(transform);
            deck[i].transform.localPosition = Vector3.zero;
            deck[i].gameObject.SetActive(false);
        }
        base.Start();
    }
}

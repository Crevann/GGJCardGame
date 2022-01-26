using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemsDeck : Deck<Problem>
{
    [SerializeField] ScriptableProblems[] problemsToCreate;
    [SerializeField] Problem originalPrefab;
    public override void Start() {
        deck = new Problem[problemsToCreate.Length];
        for (int i = 0; i < problemsToCreate.Length; i++) {
            deck[i] = Instantiate(originalPrefab, transform);
            deck[i].transform.position = MatchStats.Instance.problemDeckPos.position;
            deck[i].problemsData = problemsToCreate[i];
            deck[i].transform.position = transform.position;
            deck[i].gameObject.SetActive(false);
        }
        base.Start();
    }
}

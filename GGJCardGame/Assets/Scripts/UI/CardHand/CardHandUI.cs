using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandUI : MonoBehaviour
{
    private float spacing;
    [SerializeField] private float handSize;
    void Update()
    {
        DisplayCards();
    }

    private void DisplayCards() {
        Minor[] currentCards = MatchStats.Instance.CurrentMinorArcanaHand;
        int cardsInHand = MatchStats.Instance.CurrentMinorArcanaInHand();
        spacing = cardsInHand > 2 ? handSize / (cardsInHand - 1) : handSize;
        for (int i = 0; i < currentCards.Length; i++) {
            if(currentCards[i] != null) {
                currentCards[i].transform.SetParent(transform);
                float cardLocalPosition = cardsInHand > 1 ?
                    spacing * i :
                    handSize * 0.5f;
                currentCards[i].transform.localPosition = new Vector2(cardLocalPosition, 0);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y, 0), new Vector3(transform.position.x + handSize, transform.position.y, 0));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplacement : MonoBehaviour
{
    private float spacing;
    [SerializeField] private float handSize;
    private static CardDisplacement instance;
    public static CardDisplacement Instance {
        get {
            return instance;
        }
    }
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    public void DisplayCards() {
        Minor[] currentCards = MatchStats.Instance.CurrentMinorArcanaHand;
        int cardsInHand = MatchStats.Instance.CurrentMinorArcanaInHand();
        spacing = cardsInHand > 2 ? handSize / (cardsInHand - 1) : handSize;
        int cardNumber = 0;
        for (int i = 0; i < currentCards.Length; i++) {
            if(currentCards[i] != null) {
                currentCards[i].transform.SetParent(transform);
                float cardLocalPosition = cardsInHand > 1 ?
                    spacing * cardNumber :
                    handSize * 0.5f;
                Vector3 targetPos = new Vector3(transform.position.x + cardLocalPosition, transform.position.y, 0);
                currentCards[i].MoveTo(targetPos, false, false);
                cardNumber++;
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y, 0), new Vector3(transform.position.x + handSize, transform.position.y, 0));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCardLogic : MonoBehaviour
{
    [SerializeField] [Range(0, 9)] int numberToReach = 0;
    int oldNumberToReach;
    int currentNumber = 0;
    [SerializeField] Sprite[] allNumers = new Sprite[20];
    [SerializeField] FlipCard[] cards = new FlipCard[3];
    [SerializeField] FlipCardLogic nextDigit = null;
    [SerializeField] float singleFlipTime = 0.5f;
    float currentFlipTime = 0;

    void Start()
    {
        oldNumberToReach = numberToReach;
        //for (int i = 0; i < cards.Length; i++) {
            cards[0].Flip(allNumers[10]);
        cards[0].GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
        cards[0].location = FlipCard.Location.down;
            cards[1].SetImmageHidden(allNumers[0]);
        cards[1].GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
        cards[1].location = FlipCard.Location.up;
            cards[2].SetImmageHidden(allNumers[1]);
        cards[2].GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
        cards[2].location = FlipCard.Location.back;
        
    }
    public void ChangeDigit(int number = -1) {
        if(number >= 0) {
            if (nextDigit) nextDigit.ChangeDigit((int)( number / 10));
            numberToReach = number % 10;
            if (currentNumber != numberToReach) currentNumber++;
            else return;
        } else {
            if(++currentNumber == 10) {
                currentNumber = 0;
                if(nextDigit) nextDigit.ChangeDigit(number / 10);
            }
        }
        MatchStats.Instance.button.gameObject.SetActive(false);
        currentFlipTime = singleFlipTime;
        oldNumberToReach = numberToReach;
        for (int i = 0; i < cards.Length; i++) {
            switch (cards[i].location) {
                case FlipCard.Location.up:
                    cards[i].Flip(allNumers[currentNumber + 10]);
                    cards[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
                    cards[i].location = FlipCard.Location.down;
                    break;
                case FlipCard.Location.down:
                    cards[i].location = FlipCard.Location.back;

                    cards[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
                    break;
                case FlipCard.Location.back:
                    cards[i].SetImmageHidden(allNumers[currentNumber]);
                    cards[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
                    cards[i].location = FlipCard.Location.up;
                    break;
                default:
                    break;
            }
        }
    }
    public void DigitFlipped() {
        if (currentNumber != numberToReach) {
            ChangeDigit();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(numberToReach != oldNumberToReach) {
            DigitFlipped();
            oldNumberToReach = numberToReach;
        }
        if (currentFlipTime > 0) currentFlipTime -= Time.deltaTime;
        else if (currentFlipTime != Mathf.Infinity && MatchStats.Instance.shouldButtonBeActive) {
            MatchStats.Instance.button.gameObject.SetActive(true);
            currentFlipTime = Mathf.Infinity;
        }
    }
}

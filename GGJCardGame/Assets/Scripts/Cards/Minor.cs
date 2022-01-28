using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Minor : Card {
    [SerializeField] [ColorUsage(true, true)] private Color glowOff;
    [SerializeField] [ColorUsage(true, true)] private Color glowOn;
    [SerializeField] private float colorGlowSpeed;
    private SpriteRenderer sr;
    private bool isPlayed;
    string cardName;
    int soulCoinsCost;
    int bodyIngotCost;
    int soul, body;
    public float stabilityGain = Mathf.Infinity;

    [SerializeField] private float timeToDescription = 0.5f;
    private float hoverCounter;
    private bool isHoverActive = false;
    private bool removeDescriptionWhenPossible = false;

    public bool IsHoverActive
    {
        get { return isHoverActive; }
        set
        {
            isHoverActive = value;
            if (isHoverActive)
            {
                DescriptionPage.Instance.StringToWrite = cardName + ":\n\n" +
                    MatchStats.Instance.CurrentMajorArcana.GetMinorDescription(cardName);
            } else
            {
                if (MatchStats.Instance.IsPaused)
                {
                    removeDescriptionWhenPossible = true;
                    return;
                }

                DescriptionPage.Instance.StringToWrite = null;
            }
        }
    }

    Sprite cardFace {
        set {
            GetComponent<SpriteRenderer>().sprite = value;
        }
    }
    public ScriptableMinor minorData {
        set {
            cardName = value.cardName;
            name = value.cardName + "(Minor)";
            soulCoinsCost = value.soulCoinsCost;
            bodyIngotCost = value.bodyIngotCost;
            soul = value.soul == 0 ? soulCoinsCost : value.soul;
            body = value.body == 0 ? bodyIngotCost : value.body;
            WritePrices writePrices = GetComponent<WritePrices>();
            if (writePrices) writePrices.Write(soulCoinsCost, bodyIngotCost);
            stabilityGain = value.stabilityGain != Mathf.Infinity ? value.stabilityGain : (soulCoinsCost >= bodyIngotCost ? soulCoinsCost : bodyIngotCost);
            cardFace = value.cardFace;
        }
    }

    public int SoulCoinsCost
    {
        get { return soulCoinsCost; }
    }
    public int BodyIngotCost
    {
        get { return bodyIngotCost; }
    }
    
    public int Soul
    {
        get { return soul; }
    }

    public int Body
    {
        get
        {
            return body;
        }
    }

    
    public override void Start() {
        hoverCounter = 0;
        base.Start();
        if (stabilityGain == Mathf.Infinity) {
            if (soul > body) stabilityGain = soul;
            else stabilityGain = body;
        }
    }

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        sr.material = Instantiate<Material>(sr.material);
    }


    public override void Update() {
        base.Update();
        if (CheckCostCard() && !isPlayed) {
            sr.material.color = Color.Lerp(sr.material.color, glowOn, colorGlowSpeed * Time.deltaTime);
        }
        else {
            sr.material.color = Color.Lerp(sr.material.color, glowOff, colorGlowSpeed * 3 * Time.deltaTime);
        }
        if (removeDescriptionWhenPossible && !MatchStats.Instance.IsPaused)
        {
            removeDescriptionWhenPossible = false;
            IsHoverActive = false;
        }
        
    }
    public void ResetCard() {
        isPlayed = false;   
    }

    public override void InGame()
    {
       
    }

    public void PlayCard()
    {
        isPlayed = true;
        MatchStats.Instance.CurrentBodyIngots -= bodyIngotCost;
        MatchStats.Instance.CurrentSoulCoins -= soulCoinsCost;
        MatchStats.Instance.AddCardToMajor(this);
        MatchStats.Instance.StartCardFlip();
        CardDisplacement.Instance.DisplayCards();
    }

    public bool CheckCostCard()
    {
        return MatchStats.Instance.CurrentBodyIngots >= bodyIngotCost && MatchStats.Instance.CurrentSoulCoins >= soulCoinsCost;
        
    }

    private void OnMouseOver() {
        if (MatchStats.Instance.IsPaused) return;

        if(!isHoverActive) hoverCounter += Time.deltaTime;
        if (hoverCounter >= timeToDescription && !isHoverActive)
        {
            IsHoverActive = true;
        }

    }
    private void OnMouseExit() {
        hoverCounter = 0;
        IsHoverActive = false;
    }

    private void OnMouseDown()
    {
        if (MatchStats.Instance.animator.GetCurrentAnimatorStateInfo(0).IsName("Fase 3 minor choice") && 
            CheckCostCard() && !MatchStats.Instance.IsPaused)
        {
            if (!isPlayed) {
                PlayCard();
                ShowFeedback();
            }
        }
    }
    private void ShowFeedback() {
        float stability = (float)MatchStats.Instance.GetStability() / PlayerStats.Instance.StabilityRange;
        PostProcessMGR.Instance.StartVignetting(stability);

    }
}

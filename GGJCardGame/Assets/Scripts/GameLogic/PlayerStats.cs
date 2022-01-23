using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int soul;
    public int body;
    [SerializeField] private int maxSoulCoin;
    public int MaxSoulCoin { get { return maxSoulCoin; } }
    [SerializeField] private int maxBodyIngots;
    public int MaxBodyIngots { get { return maxBodyIngots; } }
    [SerializeField] private int maxCardHard;
    public int MaxCardHard { get { return maxCardHard; } }
    [SerializeField] private int stabilityRange;
    public int StabilityRange { get { return stabilityRange; } }

    private static PlayerStats instance;
    public static PlayerStats Instance {
        get {
            return instance;
        }
    }
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
}

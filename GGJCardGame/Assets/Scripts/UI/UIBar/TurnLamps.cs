using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class TurnLamps : MonoBehaviour
{
    [SerializeField] private Lamp[] lamps;

    private static TurnLamps instance;
    public static TurnLamps Instance {
        get {
            return instance;
        }
    }


    private void Awake() {
        if(instance == null) {
            instance = this;
        }
        for (int i = 0; i < lamps.Length; i++) {
            if(i >= MatchStats.Instance.maxProblems) {
                lamps[i].gameObject.SetActive(false);
            }
        }
    }

    public void TurnOnLamp(int lamp) {
        lamps[lamp].isOn = true;
        lamps[lamp].currentFlickerTime = lamps[lamp].flickerTime;
    }

    public void TurnOffLamp(int lamp) {
        lamps[lamp].isOn = false;
    }
}

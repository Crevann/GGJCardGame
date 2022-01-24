using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterLights : MonoBehaviour
{
    [SerializeField] private GameObject[] lights;

    private void Update() {
        int light = Mathf.Clamp(-PlayerStats.Instance.soul + PlayerStats.Instance.body + 6, 0, 12);
        EnableLight(light);
    }

    private void EnableLight(int light) {
        for (int i = 0; i < lights.Length; i++) {
            if(i == light) {
                lights[i].SetActive(true);
            }
            else {
                lights[i].SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicPercetageClass : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Slider muiscSlider;
    void Start()
    {
    }

    private void Update()
    {
        text.text = "SOUND: " + Mathf.RoundToInt(muiscSlider.value * 100) + "%";
    }
}

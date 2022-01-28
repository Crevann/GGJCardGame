using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Lamp : MonoBehaviour
{
    [SerializeField] private float lampIntensity;
    [SerializeField] private float lampTurnSpeed;
    [SerializeField] private float lightFlicker;
    [SerializeField] private Image lampString;
    [SerializeField] private Light2D lampLight;
    [SerializeField] [ColorUsage(true, true)] private Color lampStringOnGlowColor;
    [SerializeField] [ColorUsage(true, true)] private Color lampStringOffGlowColor;
    public float currentFlickerTime;
    public float flickerTime;
    public bool isOn;
    private bool wasOn = false;
    private AudioSource lightSound;

    private void Awake() {
        lampString.material = Instantiate<Material>(lampString.material);
        lightSound = GetComponent<AudioSource>();
    }
    private void Update() {
        if (isOn) {
            if (!wasOn)
            {
                lightSound.Play();
            }
            lampLight.intensity = Mathf.Lerp(lampLight.intensity, lampIntensity, lampTurnSpeed * Time.deltaTime);
            lampString.material.color = Color.Lerp(lampString.material.color, lampStringOnGlowColor, lampTurnSpeed * Time.deltaTime);
            if(currentFlickerTime > 0) {
                Flicker();
                currentFlickerTime -= Time.deltaTime;
            }
            wasOn = true;
        }
        else {
            lampLight.intensity = Mathf.Lerp(lampLight.intensity, 0, lampTurnSpeed * Time.deltaTime);
            lampString.material.color = Color.Lerp(lampString.material.color, lampStringOffGlowColor, lampTurnSpeed * Time.deltaTime);
        }
    }

    private void Flicker() {
        lampLight.intensity += Random.Range(-lightFlicker, lightFlicker);
    }
}

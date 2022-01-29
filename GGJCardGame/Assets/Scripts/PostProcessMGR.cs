using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
[RequireComponent(typeof(Volume))]
public class PostProcessMGR : MonoBehaviour
{
    Volume volume = null;
    [Header("Vignette")]
    Vignette myVignette = null;
    [SerializeField] Color red, black, blue;
    [SerializeField] float maxSinSpeed = 10;
    [SerializeField] float baseIntencity = 0.232f;
    [SerializeField] SpriteRenderer fadeToBlack;
    [SerializeField] float fadeToBlackSpeed;
    float currentBaseIntencity = 0.232f;
    float speed = 0;
    void Start()
    {
        volume = GetComponent<Volume>();
        if (volume.profile.TryGet(out Vignette vignette))
            myVignette = vignette;
    }

    private static PostProcessMGR instance;
    public static PostProcessMGR Instance {
        get {
            return instance;
        }
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    public void StartVignetting(float stability) {
        //stability = Mathf.Clamp(stability, -1, 1);
        speed = Mathf.Lerp(0, maxSinSpeed, Mathf.Abs(stability));
        currentBaseIntencity = Mathf.Lerp(baseIntencity, 0.45f, Mathf.Abs(stability));
        Color c = Color.Lerp(black, stability < 0 ? blue : red, Mathf.Abs(stability));
        myVignette.color.Override(c);
    }

    public bool FadeToBlack(bool on) {
        if (on) {
            fadeToBlack.color = new Color(
                fadeToBlack.color.r, 
                fadeToBlack.color.g, 
                fadeToBlack.color.b, 
                Mathf.Lerp(fadeToBlack.color.a, 1, fadeToBlackSpeed * Time.deltaTime));
            if(fadeToBlack.color.a >= 0.995) {
                return true;
            }
        }else if (!on) {
            fadeToBlack.color = new Color(
                fadeToBlack.color.r,
                fadeToBlack.color.g,
                fadeToBlack.color.b,
                Mathf.Lerp(fadeToBlack.color.a, 0, fadeToBlackSpeed * Time.deltaTime));
            if (fadeToBlack.color.a <= 0.05) {
                return true;
            }
        }
        return false;
    }
    void Update()
    {
        
        myVignette.intensity.Override(currentBaseIntencity + Mathf.Sin(Time.time * speed) * 0.05f) ; // 0.45 + (-0.05 : 0.05)
        
    }
}

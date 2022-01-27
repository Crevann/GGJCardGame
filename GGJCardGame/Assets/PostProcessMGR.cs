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
    void Start()
    {
        volume = GetComponent<Volume>();
        if (volume.profile.TryGet(out Vignette vignette))
            myVignette = vignette;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}

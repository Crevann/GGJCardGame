using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlipCard : MonoBehaviour
{
    public enum Location { up, down, back}
    [HideInInspector] public Location location;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite imageToSet;
    [SerializeField] bool flipDown = false;
    [SerializeField] float rotationSpeed = 3;
    float t = 0;
    void Start()
    {
        
    }
    public void Flip(Sprite image) {
        imageToSet = image;
        flipDown = true;
    }
    public void SetImmageHidden(Sprite image) {
        imageToSet = image;
        flipDown = false;
    }
    void Update()
    {
        
        if (flipDown && imageToSet) {
            if (t < 1) t += Time.deltaTime * rotationSpeed;
            else t = 1;
            transform.localScale = Vector3.up * Mathf.Lerp(1, 0, t) + Vector3.right;
            if (t > 0.99) {
                spriteRenderer.sprite = imageToSet;
                imageToSet = null;
                t = 0;
            }
        }else if(flipDown && !imageToSet) {
            if (t < 1) t += Time.deltaTime * rotationSpeed;
            else t = 1;
            transform.localScale = Vector3.up * Mathf.Lerp(0, 1, t)+ Vector3.right;
            transform.localPosition = Vector3.up * Mathf.Lerp(0, -0.37f, t) ;
            if (t > 0.99) {
                flipDown = false;
                t = 0;
                GetComponentInParent<FlipCardLogic>().DigitFlipped();
            }
        }else if(!flipDown && imageToSet) {
            transform.localScale = Vector3.up + Vector3.right;
            transform.localPosition = Vector3.zero;
            spriteRenderer.sprite = imageToSet;
            imageToSet = null;
        }

    }
}

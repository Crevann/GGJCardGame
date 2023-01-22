using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardShufflingLogic : MonoBehaviour
{

    [SerializeField]
    private Sprite[] shufflingImages;

    private Image currentImage;

    private void Awake()
    {
        currentImage = gameObject.GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentImage.sprite = shufflingImages[Random.Range(0, shufflingImages.Length)];
    }

}

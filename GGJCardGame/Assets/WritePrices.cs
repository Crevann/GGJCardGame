using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WritePrices : MonoBehaviour
{
    [SerializeField] TextMeshPro soulCoins, bodyIngots;
    void Start()
    {
        
    }

    public void Write(int soul, int body) {
        soulCoins.text = soul.ToString();
        bodyIngots.text = body.ToString();
    }
}

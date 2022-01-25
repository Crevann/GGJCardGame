using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritePrices : MonoBehaviour
{
    [SerializeField] TextMesh soulCoins, bodyIngots;
    void Start()
    {
        
    }

    public void Write(int soul, int body) {
        soulCoins.text = soul.ToString();
        bodyIngots.text = body.ToString();
    }
}

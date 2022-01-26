using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonDisplay : MonoBehaviour
{
    [SerializeField]
    private bool isActive;
    [SerializeField]
    private char activeChar;
    [SerializeField]
    private char inactiveChar;

    private TextMeshProUGUI text;

    public void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }


    public void ToggleActive()
    {
        isActive = !isActive;
        if (isActive) text.text = "" + activeChar;
        else text.text = "" + inactiveChar;
    }
}

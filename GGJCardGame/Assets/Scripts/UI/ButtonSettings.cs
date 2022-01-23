using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSettings : MonoBehaviour
{
    [SerializeField] Button buttonSettings;

    void Start()
    {
        buttonSettings.onClick.AddListener(ChangeSettingsScene);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ChangeSettingsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }
}

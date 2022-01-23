using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBackToMenu : MonoBehaviour
{
    [SerializeField] Button buttonBackToMenu;

    void Awake()
    {
        buttonBackToMenu.onClick.AddListener(ChangeGameScene);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ChangeGameScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

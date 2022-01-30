using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonTutorial : MonoBehaviour
{
    [SerializeField] Button buttonNewGame;

    void Awake()
    {
        buttonNewGame.onClick.AddListener(ChangeTutorialScene);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeTutorialScene()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}

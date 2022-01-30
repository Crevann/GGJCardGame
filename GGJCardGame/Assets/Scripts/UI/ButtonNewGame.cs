using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonNewGame : MonoBehaviour
{
    [SerializeField]Button buttonNewGame;

    void Awake()
    {
        buttonNewGame.onClick.AddListener(ChangeGameScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeGameScene()
    {
        StaticLogic.matchNumber = 1;
        StaticLogic.body = 0;
        StaticLogic.soul = 0;
        SceneManager.LoadScene("GameScene");
    }
    public void ChangeResumeGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}

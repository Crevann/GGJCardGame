using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    [SerializeField] Button buttonNewGame;

    void Awake()
    {
        buttonNewGame.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}

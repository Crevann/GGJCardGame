using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonCredits : MonoBehaviour
{
    [SerializeField] Button buttonNewGame;

    void Awake()
    {
        buttonNewGame.onClick.AddListener(ChangeCreditsScene);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeCreditsScene() {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}

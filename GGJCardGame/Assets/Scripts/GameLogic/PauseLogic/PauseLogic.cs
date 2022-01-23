using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseLogic : MonoBehaviour
{
    private bool isPaused;
    private Transform pausePanel;
    private static PauseLogic instance;

    public static PauseLogic Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PauseLogic();
            }
            return instance;
        }
    }

    public bool IsPaused
    {
        get { return isPaused; }
        set
        {
            if (value && !isPaused) Pause();
            if (!value && isPaused) Resume();
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            if (child.gameObject.tag == "PausePanel")
            {
                pausePanel = child;
                return;
            }
        }
    }

    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            IsPaused = !IsPaused;
        }
    }

    void Pause()
    {
        pausePanel.gameObject.SetActive(true);
        isPaused = true;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    void Resume()
    {
        pausePanel.gameObject.SetActive(false);
        isPaused = false;
    }
}

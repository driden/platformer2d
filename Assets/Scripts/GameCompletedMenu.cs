using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCompletedMenu : MonoBehaviour
{
    [SerializeField]
    public Button quitButton;
    
    [SerializeField]
    public Button tryAgainButton;

    public void Start()
    {
        if (quitButton) quitButton.onClick.AddListener(HandleQuitButton);
        if (tryAgainButton) tryAgainButton.onClick.AddListener(HandleTryAgainButton);
    }

    private void HandleQuitButton()
    {
        Application.Quit();
    }
    
    private void HandleTryAgainButton()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }
}

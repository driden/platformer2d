using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCompletedMenu : MonoBehaviour
{
    [SerializeField]
    public Button quitButton;

    public void Start()
    {
        if (quitButton) quitButton.onClick.AddListener(HandleQuitButton);
    }

    private void HandleQuitButton()
    {
        // Debug.Log("Test");
        Application.Quit();
    }
}

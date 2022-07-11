using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
//using static ItemCollector;


public class GameCompletedMenu : MonoBehaviour
{
    [SerializeField]
    public Button quitButton;
    
    [SerializeField]
    public Button tryAgainButton;

    [SerializeField] 
    public TextMeshProUGUI score;

    public void Start()
    {
        if (quitButton) quitButton.onClick.AddListener(HandleQuitButton);
        if (tryAgainButton) tryAgainButton.onClick.AddListener(HandleTryAgainButton);
        SetScore();
    }

    private void HandleQuitButton()
    {
        Application.Quit();
    }
    
    private void HandleTryAgainButton()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }

    private void SetScore()
    {
        //TODO: Revisar porque da null pero despues funciona ok
        score.text = "Score: " + ItemCollector.GetScore();
    }

}

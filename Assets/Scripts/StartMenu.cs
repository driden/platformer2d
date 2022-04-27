using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartMenu : MonoBehaviour
{
    [SerializeField]
    public Button startGameButton;

    public void Start()
    {
        if (startGameButton)
        {
            startGameButton.onClick.AddListener(HandleStartGameButton);
        }
    }
    
    public void HandleStartGameButton()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }
}

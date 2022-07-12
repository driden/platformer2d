using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


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
        Pumpkins.ResetPumpkins();
        SceneManager.LoadScene("Scenes/Level1");
    }

    private void SetScore()
    {
        //TODO: Revisar porque da null pero despues funciona ok
        if (score) score.text = "Score: " + Pumpkins.GetPumpkins();
    }

}

using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject pausedUI;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private GameObject gameOverUI;

    public void ShowMainMenu()
    {
        HideAllUI();
        mainMenuUI.SetActive(true);
    }

    public void ShowGameplayUI()
    {
        HideAllUI();
        gameplayUI.SetActive(true);
    }

    public void ShowPausedUI()
    {
        HideAllUI();
        gameplayUI.SetActive(true);
        pausedUI.SetActive(true);
    }

    public void ShowOptionsUI()
    {
        HideAllUI();
        settingsUI.SetActive(true);
    }

    public void ShowGameOverUI()
    {
        HideAllUI();
        gameOverUI.SetActive(true);
    }

    public void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        pausedUI.SetActive(false);
        settingsUI.SetActive(false);
        gameOverUI.SetActive(false);
    }
}

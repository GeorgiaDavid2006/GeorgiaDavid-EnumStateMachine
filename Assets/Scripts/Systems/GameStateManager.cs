using UnityEngine;

public enum GameState
{
    None,
    Init,
    MainMenu,
    Gameplay,
    Paused,
    Settings,
    GameOver
}

public class GameStateManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    public GameState currentState { get; private set; }
    public GameState previousState { get; private set; }

    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;

    private void Start()
    {
        uiManager.GetComponent<UIManager>();
        SetState(GameState.Init);
    }

    public void SetState(GameState newState)
    {
        previousState = currentState;
        currentState = newState;

        previousActiveState = previousState.ToString();
        currentActiveState = currentState.ToString();

        OnGameStateChanged(previousState, currentState);
    }

    private void OnGameStateChanged(GameState previousState, GameState newState)
    {
        switch(newState)
        {
            case GameState.None:
                Debug.Log("No GameState");

                break;
            case GameState.Init:
                Debug.Log("GameState = Init");
                
                break;

            case GameState.MainMenu:
                Debug.Log("GameState = MainMenu");
                uiManager.ShowMainMenu();
                break;

            case GameState.Gameplay:
                Debug.Log("GameState = Gameplay");
                uiManager.ShowGameplayUI();
                break;

            case GameState.Paused:
                Debug.Log("GameState = Paused");
                uiManager.ShowPausedUI();
                break;

            case GameState.Settings:
                Debug.Log("GameState = Settings");
                uiManager.ShowOptionsUI();
                break;

            case GameState.GameOver:
                Debug.Log("GameState = Game Over");
                uiManager.ShowGameOverUI();
                break;

            default:
                break;
                
        }
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentState == GameState.Gameplay)
            {
                SetState(GameState.GameOver);
            }
        }
    }

    public void MainMenu()
    {
        SetState(GameState.MainMenu);
    }

    public void StartGame()
    {
        SetState(GameState.Gameplay);
    }

    public void TogglePause()
    {
        Debug.Log("Escape pressed");

        if (currentState == GameState.Paused)
        {
            if (currentState == GameState.Gameplay) return;
            SetState(GameState.Gameplay);
        }

        else if (currentState == GameState.Gameplay)
        {
            if (currentState == GameState.Paused) return;
            SetState(GameState.Paused);
        }
    }

    public void Settings()
    {
        SetState(GameState.Settings);
    }

    public void ReturnFromSettings()
    {
        if (previousState == GameState.MainMenu)
        {
            SetState(GameState.MainMenu);
        }
        else if (previousState == GameState.Paused)
        {
            SetState(GameState.Paused);
        }
    }

    public void GameOver()
    {
        SetState(GameState.GameOver);
    }
}

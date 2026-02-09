using UnityEngine;

public enum GameState
{
    None,
    Init,
    MainMenu,
    Gameplay,
    Paused
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
        uiManager = GetComponent<UIManager>();
        SetState(GameState.Init);
    }

    public void SetState(GameState newState)
    {
        previousState = currentState;
        currentState = newState;

        previousActiveState = previousState.ToString();
        currentActiveState = currentState.ToString();
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

            default:
                break;
                
        }
    }

    private void Update()
    {
       
    }
}

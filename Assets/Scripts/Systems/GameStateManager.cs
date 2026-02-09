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
    public GameState State;

    public GameState currentState { get; private set; }
    public GameState previousState { get; private set; }

    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;

    private void Start()
    {
        SetState(GameState.Init);
    }

    public void SetState(GameState newState)
    {
        previousState = currentState;
        currentState = newState;

        previousActiveState = previousState.ToString();
        currentActiveState = currentState.ToString();
    }

    private void OnGameStateChanged()
    {

    }

    private void Update()
    {
       
    }
}

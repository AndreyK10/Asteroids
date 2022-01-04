using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
        
    [SerializeField] private HealthController HealthController;

    private GameState _gameState;

    public event Action<GameState> OnGameStateChanged;

    private void OnEnable()
    {
        HealthController.OnDestroyed += OnDestroyed;
    }

    private void Start()
    {
        _gameState = GameState.StartScreen;
        OnGameStateChanged?.Invoke(_gameState);
    }

    public void PlayGame()
    {
        _gameState = GameState.Gameplay;
        OnGameStateChanged?.Invoke(_gameState);
    }

    private void OnDestroyed()
    {
        _gameState = GameState.EndScreen;
        OnGameStateChanged?.Invoke(_gameState);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void CloseGame()
    {
        Application.Quit();
    }    

    private void OnDisable()
    {
        HealthController.OnDestroyed -= OnDestroyed;
    }
}

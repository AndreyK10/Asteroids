using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private GameConfig GameConfig;
    [SerializeField] private AsteroidController AsteroidController;
    [SerializeField] private UIController UIController;
    [SerializeField] private Player Player;
    [SerializeField] private GameStateController GameStateController;

    private void OnEnable()
    {
        GameStateController.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.StartScreen:
                UIController.SetBackground(GameConfig.BackgroundTile);
                Player.SetStats(GameConfig);
                break;

            case GameState.Gameplay:
                AsteroidController.InstantiateAsteroids(GameConfig);
                break;

            case GameState.EndScreen:
                break;

            default:
                break;
        }
    }

    private void OnDisable()
    {
        GameStateController.OnGameStateChanged -= OnGameStateChanged;
    }

}

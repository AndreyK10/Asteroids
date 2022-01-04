using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private ScoreCounter ScoreCounter;
    [SerializeField] private HealthController HealthController;
    [SerializeField] private GameStateController GameStateController;

    [SerializeField] private Image[] _backgroundTiles;
    [SerializeField] private Image _shieldImage;

    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private Button _playButton, _restartButton, _closeButton;

    [SerializeField] private Animator _damageAnimator;

    private float _initialShieldsNumber;
    private float _currentShieldsNumber;


    private void OnEnable()
    {
        ScoreCounter.OnScoreIncreased += OnScoreIncreased;
        HealthController.OnShieldsSet += OnShieldsSet;
        HealthController.OnShieldsChanged += OnShieldsChanged;
        GameStateController.OnGameStateChanged += OnGameStateChanged;        
    }
private void OnGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.StartScreen:
                DisplayButtons(playButton: true, restartButton: false, closeButton: false);
                break;

            case GameState.Gameplay:
                DisplayButtons(playButton: false, restartButton: false, closeButton: false);
                break;

            case GameState.EndScreen:
                DisplayButtons(playButton: false, restartButton: true, closeButton: true);
                break;

            default:
                break;
        }
    }

    public void SetBackground(Sprite sprite)
    {
        foreach (var item in _backgroundTiles)
        {
            item.sprite = sprite;
        }
    }

    private void OnShieldsSet(float initialShieldsNumber)
    {
        _initialShieldsNumber = initialShieldsNumber;
        _currentShieldsNumber = initialShieldsNumber;
        UpdateShieldsImage();
    }
    
    private void OnShieldsChanged(float currentShieldsNumber)
    {
        PlayAnimation();
        _currentShieldsNumber = currentShieldsNumber;
        UpdateShieldsImage();
    }

    private void OnScoreIncreased(int score)
    {
        _scoreText.text = score.ToString();
    }     

    private void PlayAnimation()
    {
        _damageAnimator.Play("DamageAnimation");
    }

    private void UpdateShieldsImage()
    {
        _shieldImage.fillAmount = _currentShieldsNumber / _initialShieldsNumber;
    }   

    private void DisplayButtons(bool playButton, bool restartButton, bool closeButton)
    {
        _playButton.gameObject.SetActive(playButton);
        _restartButton.gameObject.SetActive(restartButton);
        _closeButton.gameObject.SetActive(closeButton);
    }
    private void OnDisable()
    {
        ScoreCounter.OnScoreIncreased -= OnScoreIncreased;
        HealthController.OnShieldsSet -= OnShieldsSet;
        HealthController.OnShieldsChanged -= OnShieldsChanged;
        GameStateController.OnGameStateChanged -= OnGameStateChanged;
    }
}

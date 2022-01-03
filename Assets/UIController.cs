using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image[] _backgroundTiles;
    [SerializeField] private ScoreCounter ScoreCounter;
    [SerializeField] private TextMeshProUGUI _scoreText;


    private void OnEnable()
    {
        ScoreCounter.OnScoreIncreased += OnScoreIncreased;
    }

    public void SetBackground(Sprite sprite)
    {
        foreach (var item in _backgroundTiles)
        {
            item.sprite = sprite;
        }
    }

    private void OnScoreIncreased(int score)
    {
        _scoreText.text = score.ToString();
    }

    private void OnDisable()
    {
        ScoreCounter.OnScoreIncreased -= OnScoreIncreased;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Player Player;
    private int _score;

    public event Action<int> OnScoreIncreased;


    private void OnEnable()
    {
        Player.OnAsteroidDestroyed += OnAsteroidDestroyed;
    }
    private void Start()
    {
        _score = 0;
    }

    private void OnAsteroidDestroyed(Asteroid asteroid)
    {
        _score++;
        OnScoreIncreased?.Invoke(_score);
    }
    private void OnDisable()
    {
        Player.OnAsteroidDestroyed -= OnAsteroidDestroyed;
    }
}

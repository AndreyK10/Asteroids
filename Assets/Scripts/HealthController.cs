using UnityEngine;
using System;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Player Player;
    [SerializeField] private ExplosionEffect ExplosionEffect;

    private float _playerHealth;
    private float _playerShields;

    public event Action<float> OnShieldsChanged;
    public event Action<float> OnShieldsSet;
    public event Action OnDestroyed;

    private void OnEnable()
    {
        Player.OnStatsSet += OnStatsSet;
        Player.OnAsteroidTouched += OnAsteroidTouched;
    }

    private void OnStatsSet(float playerHealth, float playerShields)
    {
        _playerHealth = playerHealth;
        _playerShields = playerShields;
        OnShieldsSet?.Invoke(_playerShields);
    }

    private void OnAsteroidTouched(Asteroid asteroid)
    {
        if (_playerShields > 0)
        {
            _playerShields--;
            OnShieldsChanged?.Invoke(_playerShields);
        }
        else
        {
            if (_playerHealth > 0)
            {
                _playerHealth--;
                if (_playerHealth <= 0)
                {
                    OnDestroyed?.Invoke();
                    ExplosionEffect.Explode(Player.transform.position);
                    Player.HidePlayer();
                }
            }
        }
    }

    private void OnDisable()
    {
        Player.OnStatsSet -= OnStatsSet;
        Player.OnAsteroidTouched -= OnAsteroidTouched;

    }
}

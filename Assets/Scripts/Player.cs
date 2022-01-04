using UnityEngine;
using System;

[RequireComponent(typeof(StayOnScreen))]
public class Player : MonoBehaviour
{    
    [SerializeField] private Gun Gun;
    [SerializeField] private PlayerMovement PlayerMovement;

    
    private float _playerHealth;
    private float _playerShields;


    public event Action<Asteroid> OnAsteroidTouched;
    public event Action<Asteroid> OnAsteroidDestroyed;
    public event Action<float, float> OnStatsSet;

    private void OnEnable()
    {
        Gun.OnAsteroidShot += OnAsteroidShot;
    }

    public void SetStats(GameConfig config)
    {
        PlayerMovement.SetStats(config.PlayerSpeed, config.PlayerKeyRotationSpeed, config.PlayerAutoRotationSpeed);
        _playerHealth = config.PlayerHealth;
        _playerShields = config.PlayerShields;
        OnStatsSet?.Invoke(_playerHealth, _playerShields);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Gun.Shoot();
        }
    }

    public void HidePlayer()
    {
        gameObject.SetActive(false);
    }

    private void OnAsteroidShot(Asteroid asteroid)
    {
        OnAsteroidDestroyed?.Invoke(asteroid);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Asteroid asteroid))
        {
            if (asteroid.IsDangerous == true)
            {
                OnAsteroidTouched?.Invoke(asteroid);
            }
        }
    }

    private void OnDisable()
    {
        Gun.OnAsteroidShot -= OnAsteroidShot;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] private AsteroidCreator AsteroidCreator;
    [SerializeField] private Player Player;

    private Asteroid[] _pool;
    private Vector2 _tempPosition;


    private void OnEnable()
    {
        Player.OnAsteroidTouched += OnAsteroidTouched;
        Player.OnAsteroidDestroyed += OnAsteroidDestroyed;
    }

    public void InstantiateAsteroids(GameData gameData)
    {
        _pool = AsteroidCreator.CreatePool(gameData.PoolSize, gameData);

        foreach (var item in _pool)
        {
            do
            {
                _tempPosition = GetRandomPosition();
            }
            while ((_tempPosition.x <= 1 && _tempPosition.x >= -1) && (_tempPosition.y <= 1 && _tempPosition.y >= -1));
            Instantiate(item,_tempPosition, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
    }

    private void ResetAsteroid(Asteroid asteroid)
    {
        asteroid.gameObject.SetActive(false);
        asteroid.transform.position = GetRandomPosition();
        asteroid.gameObject.SetActive(true);
        asteroid.ResetAsteroidStatus();
    }

    private void OnAsteroidTouched(Asteroid asteroid)
    {
        ResetAsteroid(asteroid);
    }

    private Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
    }

    private void OnAsteroidDestroyed(Asteroid asteroid)
    {
        ResetAsteroid(asteroid);
    }
    private void OnDisable()
    {
        Player.OnAsteroidTouched -= OnAsteroidTouched;
        Player.OnAsteroidDestroyed -= OnAsteroidDestroyed;

    }

}

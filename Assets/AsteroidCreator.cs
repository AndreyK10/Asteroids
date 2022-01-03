using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreator : MonoBehaviour
{

    [SerializeField] private Asteroid[] _asteroidPrefabs;

    private Asteroid[] _asteroidsPool;
    private Asteroid _temp;

    public Asteroid[] CreatePool(int poolSize, GameData data)
    {
        _asteroidsPool = new Asteroid[poolSize];

        for (int i = 0; i < _asteroidsPool.Length; i++)
        {
            _temp = _asteroidPrefabs[Random.Range(0, _asteroidPrefabs.Length)];
            _temp.SetData(Random.Range(data.MinSpeed, data.MaxSpeed), data.TimeBeforeDangerous);
            var tempSize = Random.Range(data.MinSize, data.MaxSize);
            _temp.transform.localScale = new Vector2(tempSize, tempSize);
            _asteroidsPool[i] = _temp;
        }

        return _asteroidsPool;
    }
}

using UnityEngine;

public class AsteroidCreator : MonoBehaviour
{   

    private Asteroid[] _asteroidsPool;
    private Asteroid _temp;

    public Asteroid[] CreatePool(int poolSize, GameConfig config)
    {
        _asteroidsPool = new Asteroid[poolSize];

        for (int i = 0; i < _asteroidsPool.Length; i++)
        {
            _temp = config.AsteroidPrefabs[Random.Range(0, config.AsteroidPrefabs.Length)];
            _temp.SetData(Random.Range(config.MinSpeed, config.MaxSpeed), config.TimeBeforeDangerous);
            var tempSize = Random.Range(config.MinSize, config.MaxSize);
            _temp.transform.localScale = new Vector2(tempSize, tempSize);
            _asteroidsPool[i] = _temp;
        }

        return _asteroidsPool;
    }
}

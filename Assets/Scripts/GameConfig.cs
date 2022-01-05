using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Config", menuName = "Create New Config")]
public class GameConfig : ScriptableObject
{
    [Header("Player Stats")]
    [Min(1)]
    [SerializeField] private float _playerSpeed;
    [Min(1)]
    [SerializeField] private float _playerKeyRotationSpeed;
    [Min(1)]
    [SerializeField] private float _playerAutoRotationSpeed;
    [Min(1)]
    [SerializeField] private float _playerHealth;
    [Min(0)]
    [SerializeField] private float _playerShields;

    [Header("Asteroids")]
    [SerializeField] private Asteroid[] _asteroidPrefabs;

    [Header("Min and Max Asteroid Speed")]
    [Min(0)]
    [SerializeField] private float _minSpeed;
    [Min(0)]
    [SerializeField] private float _maxSpeed;

    [Header("Min and Max Asteroid Size")]
    [Min(0.1f)]
    [SerializeField] private float _minSize;
    [Min(0.1f)]
    [SerializeField] private float _maxSize;

    [Header("Time Before Asteroid Dangerous")]
    [Min(0)]
    [SerializeField] private float _timeBeforeDangerous;

    [Header("Asteroid Pool Size")]
    [Min(0)]
    [SerializeField] private int _poolSize;

    [Header("Background Tile")]
    [SerializeField] private Sprite _backgroundTile;

    public float PlayerSpeed => _playerSpeed;
    public float PlayerKeyRotationSpeed => _playerKeyRotationSpeed;
    public float PlayerAutoRotationSpeed => _playerAutoRotationSpeed;
    public float PlayerHealth => _playerHealth;
    public float PlayerShields => _playerShields;
    public Asteroid[] AsteroidPrefabs => _asteroidPrefabs;
    public float MinSpeed => _minSpeed;
    public float MaxSpeed => _maxSpeed;
    public float MinSize => _minSize;
    public float MaxSize => _maxSize;
    public float TimeBeforeDangerous => _timeBeforeDangerous;
    public int PoolSize => _poolSize;
    public Sprite BackgroundTile => _backgroundTile;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(StayOnScreen))]
public class Player : MonoBehaviour, IMovable
{
    private float _playerSpeed;
    private float _playerKeyRotationSpeed;
    private float _playerAutoRotationSpeed;

    private float _horizontal;

    public event Action<Asteroid> OnAsteroidTouched;
    public event Action<Asteroid> OnAsteroidDestroyed;
    

    private Camera _camera;
    private Vector2 _direction;
    private float _angle;
    private Quaternion _rotation;

    [SerializeField] private ShipFlames ShipFlames;
    [SerializeField] private Gun Gun;

    private void OnEnable()
    {
        Gun.OnAsteroidShot += OnAsteroidShot;
    }

    private void OnAsteroidShot(Asteroid asteroid)
    {
        OnAsteroidDestroyed?.Invoke(asteroid);
    }

    public void SetStats(GameData data)
    {
        _playerSpeed = data.PlayerSpeed;
        _playerKeyRotationSpeed = data.PlayerKeyRotationSpeed;
        _playerAutoRotationSpeed = data.PlayerAutoRotationSpeed;
    }

    private void Awake()
    {
        _camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move();
            ShipFlames.EnableFlame();
        }
        else
        {
            ShipFlames.DisableFlame();
        }

        _horizontal = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.forward * -_horizontal * _playerKeyRotationSpeed * Time.deltaTime);

        _direction = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
         
        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && _direction.magnitude > 0.8)
        {
            _angle = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg;
            _rotation = Quaternion.AngleAxis(_angle, Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, _playerAutoRotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Gun.Shoot();
        }

    }

    public void Move()
    {
        transform.Translate(Vector2.up * _playerSpeed * Time.deltaTime, Space.Self);
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

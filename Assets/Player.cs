using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour, IStayOnScreen, IMovable
{
    private Vector2 _tempPosition;

    private float _playerSpeed;
    private float _playerKeyRotationSpeed;
    private float _playerAutoRotationSpeed;

    private float _horizontal;

    public event Action<Asteroid> OnDestroyed;

    private Camera _camera;
    private Vector2 _direction;
    private float _angle;
    private Quaternion _rotation;


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
        }

        _horizontal = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.forward * -_horizontal * _playerKeyRotationSpeed * Time.deltaTime);

        _direction = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
         
        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && _direction.magnitude > 0.5)
        {
            _angle = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg;
            _rotation = Quaternion.AngleAxis(_angle, Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, _playerAutoRotationSpeed * Time.deltaTime);
        }
    }

    private void OnBecameInvisible()
    {
        StayOnScreen();
    }


    public void StayOnScreen()
    {
        _tempPosition = transform.position;
        _tempPosition *= -1;
        transform.position = _tempPosition;
    }

    public void Move()
    {
        transform.Translate(Vector2.up * _playerSpeed * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Asteroid asteroid))
        {
            if (asteroid.IsDangerous == true)
            {
                OnDestroyed?.Invoke(asteroid);
            }
        }
    }
}

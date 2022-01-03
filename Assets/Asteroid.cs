using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PolygonCollider2D))]
public class Asteroid : MonoBehaviour, IStayOnScreen, IMovable
{
    [SerializeField] private float _speed;
    private Vector2 _tempPosition;
    [SerializeField] private bool _isDangerous = false;
    [SerializeField] private float _timeBeforeDangerous;
    public bool IsDangerous => _isDangerous;

    private void Start()
    {
        StartCoroutine(ChangeStatus());
    }

    private void Update()
    {
        Move();
    }
    public void SetData(float speed, float timeBeforeDangerous)
    {
        _speed = speed;
        _timeBeforeDangerous = timeBeforeDangerous;
        //SetRotation();

    }

    public void StayOnScreen()
    {
        _tempPosition = transform.position;
        _tempPosition *= -1;
        transform.position = _tempPosition;
    }

    private void OnBecameInvisible()
    {
        StayOnScreen();
    }

    public void ResetAsteroidStatus()
    {
        SetRotation();
        StartCoroutine(ChangeStatus());
    }

    public void Move()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime, Space.Self);
    }

    private void SetRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    private IEnumerator ChangeStatus()
    {
        _isDangerous = false;
        yield return new WaitForSeconds(_timeBeforeDangerous);
        _isDangerous = true;
    }
}



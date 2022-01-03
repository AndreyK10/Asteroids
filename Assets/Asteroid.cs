using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(StayOnScreen))]
public class Asteroid : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;
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



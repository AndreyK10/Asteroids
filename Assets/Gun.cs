using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private float _time;
    [SerializeField] private float _timeLimit;

    public event Action<Asteroid> OnAsteroidShot;


    public void Shoot()
    {
        _time += Time.deltaTime;
        if (_time >= _timeLimit)
        {
            _time = 0f;
            _particleSystem.Emit(1);
        }
    }


    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out Asteroid asteroid))
        {
            OnAsteroidShot?.Invoke(asteroid);
        }
    }

}

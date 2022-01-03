using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFlames : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;


    public void EnableFlame()
    {
        _particleSystem.Play();
    }

    public void DisableFlame()
    {
        _particleSystem.Pause();
        _particleSystem.Clear();
    }


}

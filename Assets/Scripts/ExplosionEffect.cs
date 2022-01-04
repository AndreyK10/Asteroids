using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void Explode(Vector2 position)
    {
        _particleSystem.transform.position = position;
        _particleSystem.Play();
    }

}

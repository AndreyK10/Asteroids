using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour, IStayOnScreen
{
    

    [SerializeField] private float playerSpeed;
    private Vector2 _tempPosition;

    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = Random.onUnitSphere * playerSpeed;
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

}

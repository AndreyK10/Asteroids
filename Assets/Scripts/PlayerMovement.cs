using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{

    [SerializeField] private ShipFlames ShipFlames;

    private Camera _camera;
    private Vector2 _direction;
    private float _angle;
    private Quaternion _rotation;

    private float _playerSpeed;
    private float _playerKeyRotationSpeed;
    private float _playerAutoRotationSpeed;

    private float _horizontal;

    private bool canMove;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (canMove)
            {
                Move();
                ShipFlames.EnableFlame();
            }
            else
            {
                ShipFlames.DisableFlame();

            }
        }
        else
        {
            ShipFlames.DisableFlame();
        }

        _horizontal = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.forward * -_horizontal * _playerKeyRotationSpeed * Time.deltaTime);

        _direction = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (_direction.magnitude <= 0.5)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            _angle = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg;
            _rotation = Quaternion.AngleAxis(_angle, Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, _playerAutoRotationSpeed * Time.deltaTime);
        }
    }

    public void Move()
    {
        transform.Translate(Vector2.up * _playerSpeed * Time.deltaTime, Space.Self);
    }

    public void SetStats(float playerSpeed, float playerKeyRotationSpeed, float playerAutoRotationSpeed)
    {
        _playerSpeed = playerSpeed;
        _playerKeyRotationSpeed = playerKeyRotationSpeed;
        _playerAutoRotationSpeed = playerAutoRotationSpeed;
    }
}

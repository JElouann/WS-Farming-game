using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private float _speed;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
        var inputHandler = GetComponent<PlayerInputHandler>();
    }

    private void FixedUpdate() //
    {
        var dir = _playerInput.actions.FindAction("Movement").ReadValue<Vector2>();
        _rb.velocity = (new Vector3(dir.x, 0, dir.y) * _speed);

        if (dir != Vector2.zero )
        {
            _rb.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.y));
        }
    }
}

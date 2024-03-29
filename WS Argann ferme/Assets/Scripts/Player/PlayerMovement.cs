using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField]
    private float _speed;
    private Rigidbody _rb;

    private void Awake()
    {
        this._rb = this.GetComponent<Rigidbody>();
        this._playerInput = this.GetComponent<PlayerInput>();
        var inputHandler = this.GetComponent<PlayerInputHandler>();
    }

    private void FixedUpdate()
    {
        var dir = this._playerInput.actions.FindAction("Movement").ReadValue<Vector2>();
        this._rb.velocity = new Vector3(dir.x, 0, dir.y) * this._speed;
        if (dir != Vector2.zero)
        {
            this._rb.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.y));
        }
    }
}

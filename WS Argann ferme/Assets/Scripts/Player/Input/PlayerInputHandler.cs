using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput _input;

    public event Action<InputAction.CallbackContext, Vector2> Movement;

    public event Action<InputAction.CallbackContext> CycleInventoryDown;

    public event Action<InputAction.CallbackContext> CycleInventoryUp;

    public event Action<InputAction.CallbackContext> Interact;

    private void Awake()
    {
        this._input = this.GetComponent<PlayerInput>();
        this._input.onActionTriggered += this.OnInput;
    }

    private void OnInput(InputAction.CallbackContext context)
    {
        switch (context.action.name)
        {
            case "Movement":
                this.Movement?.Invoke(context, context.ReadValue<Vector2>());
                break;

            case "CycleInventoryDown":
                this.CycleInventoryDown?.Invoke(context);
                break;

            case "CycleInventoryUp":
                this.CycleInventoryUp?.Invoke(context);
                break;

            case "Interact":
                this.Interact?.Invoke(context);
                break;
        }
    }
}

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
        _input = GetComponent<PlayerInput>();
        _input.onActionTriggered += OnInput;
    }

    void OnInput(InputAction.CallbackContext context)
    {
        switch (context.action.name)
        {
            case "Movement":
                Movement?.Invoke(context, context.ReadValue<Vector2>());
                break;

            case "CycleInventoryDown":
                CycleInventoryDown?.Invoke(context);
                break;

            case "CycleInventoryUp":
                CycleInventoryUp?.Invoke(context);
                break;

            case "Interact":
                Interact?.Invoke(context);
                break;
        }
    }
}

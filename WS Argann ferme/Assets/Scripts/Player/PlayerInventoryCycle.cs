using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryCycle : MonoBehaviour
{
    public int _selectedSlotIndex {  get; private set; }
    private List<GameObject> _inventory;
    [SerializeField] private PlayerInventoryDisplayer _displayer;
    private PlayerInput playerInput; //

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>(); //
        var inputHandler = GetComponent<PlayerInputHandler>();
        inputHandler.CycleInventoryDown += CycleInventoryDown;
        inputHandler.CycleInventoryUp += CycleInventoryUp;
        _inventory = gameObject.GetComponent<PlayerInventoryMain>().InventoryV2Seeds;
    }

    private void CycleInventoryDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _selectedSlotIndex--;
            if (_selectedSlotIndex < 0)
            {
                _selectedSlotIndex = _inventory.Count-1;
            }
            _displayer.CycleUI(_selectedSlotIndex);
        }
    }

    private void CycleInventoryUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _selectedSlotIndex++;
            if (_selectedSlotIndex >= _inventory.Count)
            {
                _selectedSlotIndex = 0;
            }
            _displayer.CycleUI(_selectedSlotIndex);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryCycle : MonoBehaviour
{
    private List<GameObject> _inventory;

    [SerializeField]
    private PlayerInventoryDisplayer _displayer;

    private PlayerInput playerInput;

    public int SelectedSlotIndex { get; private set; }

    private void Awake()
    {
        this.playerInput = this.GetComponent<PlayerInput>();
        var inputHandler = this.GetComponent<PlayerInputHandler>();
        inputHandler.CycleInventoryDown += this.CycleInventoryDown;
        inputHandler.CycleInventoryUp += this.CycleInventoryUp;
        this._inventory = this.gameObject.GetComponent<PlayerInventoryMain>().InventoryV2Seeds;
    }

    /// <summary>
    /// This method is used to cycle down the inventory.
    /// </summary>
    private void CycleInventoryDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            this.SelectedSlotIndex--;
            if (this.SelectedSlotIndex < 0)
            {
                this.SelectedSlotIndex = this._inventory.Count - 1;
            }

            this._displayer.CycleUI(this.SelectedSlotIndex);
        }
    }

    /// <summary>
    /// This method is used to cycle up the inventory.
    /// </summary>
    private void CycleInventoryUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            this.SelectedSlotIndex++;
            if (this.SelectedSlotIndex >= this._inventory.Count)
            {
                this.SelectedSlotIndex = 0;
            }

            this._displayer.CycleUI(this.SelectedSlotIndex);
        }
    }
}

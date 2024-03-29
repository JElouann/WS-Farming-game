using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryMain : MonoBehaviour
{
    private PlayerInventoryCycle _inventoryCycle;

    private int _selectedSlot;

    [field: SerializeField]
    public PlayerInventoryDisplayer InventoryDisplayer { get; private set; }

    [field: SerializeField]
    public MoneyHandler MoneyHandler { get; private set; }

    [field: SerializeField]
    public List<GameObject> InventoryV2Seeds { get; private set; } = new ();

    [field: SerializeField]
    public List<int> InventoryV2Amounts { get; private set; } = new ();

    [field: SerializeField]
    public GameObject CurrentFruitHold { get; set; } = null;

    public GameObject SelectedSeed { get; private set; }

    /// <summary>
    /// This method return the seed / fruit the player currently had selected.
    /// </summary>
    public GameObject GetSelectedSeed()
    {
        return this.InventoryV2Seeds[this._inventoryCycle.SelectedSlotIndex];
    }

    /// <summary>
    /// This coroutine makes the plant grow progressively by increasing its scale over the time. Increases its parcel state in the end.
    /// </summary>
    public int GetSelectedSeedIndex()
    {
        return this._inventoryCycle.SelectedSlotIndex;
    }

    /// <summary>
    /// This method increases or decreases the amount of a certain fruit by a given value and calls the method handling the UI. (UI should be handled by an event)
    /// </summary>
    public void UpdateAmount(int amountIndex, int amountValue)
    {
        this.InventoryV2Amounts[amountIndex] += amountValue;
        this.InventoryDisplayer.UpdateAmountText(amountIndex);
    }

    /// <summary>
    /// This method changes the fruit the player currently holds and calls the method handling the UI. (UI should be handled by an event)
    /// </summary>
    public void ChangeHoldFruit(GameObject newFruit)
    {
        this.CurrentFruitHold = newFruit;
        this.InventoryDisplayer.UpdateHoldFruit(newFruit);
    }

    private void Awake()
    {
        this._inventoryCycle = this.gameObject.GetComponent<PlayerInventoryCycle>();
        this._selectedSlot = this.gameObject.GetComponent<PlayerInventoryCycle>().SelectedSlotIndex;
        this.SelectedSeed = this.InventoryV2Seeds[this._selectedSlot];
        this.MoneyHandler = this.gameObject.GetComponent<MoneyHandler>();
    }
}

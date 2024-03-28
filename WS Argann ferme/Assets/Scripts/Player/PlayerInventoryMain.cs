using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryMain : MonoBehaviour
{
    [field: SerializeField] public PlayerInventoryDisplayer _inventoryDisplayer {  get; private set; }
    [field: SerializeField] public List<GameObject> InventoryV2Seeds { get; private set; } = new (); // V2 du système d'inventaire, deux listes qui marchent ensemble (type de plante / nombre de possédées)
    [field: SerializeField] public List<int> InventoryV2Amounts { get; private set; } = new ();

    [field: SerializeField] public GameObject CurrentFruitHold { get; set; } = null;

    [field: SerializeField] public int MoneyCount { get; set; } = 100;

    private PlayerInventoryCycle _inventoryCycle;
    private int _selectedSlot;
    public GameObject SelectedSeed { get; private set; }

    private void Awake()
    {
        _inventoryCycle = gameObject.GetComponent<PlayerInventoryCycle>();
        _selectedSlot = gameObject.GetComponent<PlayerInventoryCycle>()._selectedSlotIndex;
        SelectedSeed = InventoryV2Seeds[_selectedSlot];
    }

    public GameObject GetSelectedSeed()
    {
        return InventoryV2Seeds[_inventoryCycle._selectedSlotIndex];
    }

    public int GetSelectedSeedIndex()
    {
        return _inventoryCycle._selectedSlotIndex;
    }

    public void UpdateAmount(int amountIndex, int amountValue)
    {
        InventoryV2Amounts[amountIndex] += amountValue;
        _inventoryDisplayer.UpdateAmountText(amountIndex);

    }

    public void ChangeHoldFruit(GameObject newFruit)
    {
        CurrentFruitHold = newFruit;
        _inventoryDisplayer.UpdateHoldFruit(newFruit);
    }

    public void UpdateMoneyCount(int value)
    {
        MoneyCount += value;
        _inventoryDisplayer.UpdateMoneyCount();
    }
}

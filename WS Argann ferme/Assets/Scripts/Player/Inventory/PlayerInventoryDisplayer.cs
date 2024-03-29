using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventoryDisplayer : MonoBehaviour
{
    private PlayerInventoryMain _inventory;
    
    private List<int> _inventoryAmounts;
    [SerializeField]
    private List<GameObject> _inventorySprites;
    [SerializeField]
    private List<TextMeshProUGUI> _amountTextDisplayer;
    [SerializeField]
    private List<GameObject> _holdFruitSprites;
    private int _previousSlotIndex = 0;
    private MoneyHandler _moneyHandler;
    [SerializeField]
    private TextMeshProUGUI _moneyDisplayer;

    /// <summary>
    /// This method handles on the UI the cycling between fruits in player's inventory.
    /// </summary>
    public void CycleUI(int slot)
    {
        this._inventorySprites[this._previousSlotIndex].gameObject.transform.localScale -= new Vector3(150, 150, 150);
        this._inventorySprites[slot].gameObject.transform.localScale += new Vector3(150, 150, 150);
        this._previousSlotIndex = slot;
    }

    /// <summary>
    /// This method changes on UI the fruit the player currently holds.
    /// </summary>
    public void UpdateHoldFruit(GameObject newFruit)
    {
        if (newFruit != null)
        {
            switch (newFruit.tag)
            {
                case "Banana":
                    this._holdFruitSprites[1].SetActive(false);
                    this._holdFruitSprites[2].SetActive(false);
                    this._holdFruitSprites[0].SetActive(true);
                    break;
                case "Apple":
                    this._holdFruitSprites[0].SetActive(false);
                    this._holdFruitSprites[2].SetActive(false);
                    this._holdFruitSprites[1].SetActive(true);
                    break;
                case "Orange":
                    this._holdFruitSprites[0].SetActive(false);
                    this._holdFruitSprites[1].SetActive(false);
                    this._holdFruitSprites[2].SetActive(true);
                    break;
            }
        }
        else
        {
            this._holdFruitSprites[0].SetActive(false);
            this._holdFruitSprites[1].SetActive(false);
            this._holdFruitSprites[2].SetActive(false);
        }
    }

    /// <summary>
    /// This method updates the amounts of fruit shown by the UI.
    /// </summary>
    public void UpdateAmountText(int index)
    {
        this._amountTextDisplayer[index].text = this._inventoryAmounts[index].ToString();
    }

    /// <summary>
    /// This method updates the money counter in UI.
    /// </summary>
    public void UpdateMoneyCount()
    {
        this._moneyDisplayer.text = GameObject.Find("Player").GetComponent<PlayerInventoryMain>().MoneyHandler.MoneyCount.ToString();
    }

    private void Awake()
    {
        this._inventoryAmounts = GameObject.Find("Player").GetComponent<PlayerInventoryMain>().InventoryV2Amounts;
        this._moneyDisplayer.text = GameObject.Find("Player").GetComponent<PlayerInventoryMain>().MoneyHandler.MoneyCount.ToString();
        this._inventorySprites[0].gameObject.transform.localScale = new Vector3(450, 450, 450);
        this._moneyHandler = GameObject.Find("Player").GetComponent<MoneyHandler>();
    }

    private void Start()
    {
        this.UpdateAmountText(0);
        this.UpdateAmountText(1);
        this.UpdateAmountText(2);
        this._moneyHandler.OnMoneyUpdate += this.UpdateMoneyCount;
    }
}

using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerInventoryDisplayer : MonoBehaviour
{
    private PlayerInventoryMain _inventory;
    private List<GameObject> _inventoryPlants; //
    private List<int> _inventoryAmounts; //
    
    [SerializeField] private List<GameObject> _inventorySprites;
    [SerializeField] private List<TextMeshProUGUI> _amountTextDisplayer;
    [SerializeField] private List<GameObject> _holdFruitSprites;
    
    private int _previousSlotIndex = 0;

    [SerializeField] private TextMeshProUGUI _moneyDisplayer;

    private void Awake()
    {
        _inventoryAmounts = GameObject.Find("Player").GetComponent<PlayerInventoryMain>().InventoryV2Amounts;
        _moneyDisplayer.text = GameObject.Find("Player").GetComponent<PlayerInventoryMain>().MoneyCount.ToString();
        _inventorySprites[0].gameObject.transform.localScale = new Vector3(450, 450, 450);
    }

    private void Start()
    {
        UpdateAmountText(0);
        UpdateAmountText(1);
        UpdateAmountText(2);
    }

    public void CycleUI(int slot)
    {
        _inventorySprites[_previousSlotIndex].gameObject.transform.localScale -= new Vector3(150, 150, 150);
        _inventorySprites[slot].gameObject.transform.localScale += new Vector3(150, 150, 150);
        _previousSlotIndex = slot;
    }

    public void UpdateHoldFruit(GameObject newFruit)
    {
        if (newFruit != null)
        {
            switch (newFruit.tag)
            {
                case "Banana":
                    _holdFruitSprites[1].SetActive(false);
                    _holdFruitSprites[2].SetActive(false);
                    _holdFruitSprites[0].SetActive(true);
                    break;
                case "Apple":
                    _holdFruitSprites[0].SetActive(false);
                    _holdFruitSprites[2].SetActive(false);
                    _holdFruitSprites[1].SetActive(true);
                    break;
                case "Orange":
                    _holdFruitSprites[0].SetActive(false);
                    _holdFruitSprites[1].SetActive(false);
                    _holdFruitSprites[2].SetActive(true);
                    break;
            }
        }
        else
        {
            _holdFruitSprites[0].SetActive(false);
            _holdFruitSprites[1].SetActive(false);
            _holdFruitSprites[2].SetActive(false);
        }
        
    }

    public void UpdateAmountText(int index)
    { 
        // V2 Inventory
        _amountTextDisplayer[index].text = _inventoryAmounts[index].ToString(); // change le texte du display en montant de la plante qui correspond à l'index
    }

    public void UpdateMoneyCount()
    {
        _moneyDisplayer.text = GameObject.Find("Player").GetComponent<PlayerInventoryMain>().MoneyCount.ToString();
    }
}

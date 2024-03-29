using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ShopBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _firstSelected;

    [field: SerializeField]
    public PlayerInventoryMain Inventory { get; private set; }

    [field: SerializeField]
    public PlayerInput PlayerInput { get; private set; }

    [field: SerializeField]
    public GameObject ShopMenuUI { get; private set; }

    public EventSystem EventSystem { get; private set; }

    /// <summary>
    /// This method is called when the player interacts with the shop and sells the fruit the player holds if he has one, and calls the method to open the menu otherwise
    /// </summary>
    public void OnInteract()
    {
        if (this.Inventory.CurrentFruitHold != null)
        {
            this.Inventory.MoneyHandler.UpdateMoneyCount(this.Inventory.CurrentFruitHold.GetComponent<PlantBehaviour>().PlantData.Gain);
            Destroy(this.Inventory.CurrentFruitHold);
            this.Inventory.InventoryDisplayer.UpdateHoldFruit(null);
        }
        else
        {
            this.ActiveShopMenu();
        }
    }

    private void Awake()
    {
        this.Inventory = GameObject.Find("Player").GetComponent<PlayerInventoryMain>();
        this.PlayerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        this.EventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    /// <summary>
    /// This method set to active the shop UI menu.
    /// </summary>
    private void ActiveShopMenu()
    {
        this.ShopMenuUI.SetActive(true);
        this.PlayerInput.enabled = false;
        this.EventSystem.SetSelectedGameObject(this._firstSelected);
    }
}

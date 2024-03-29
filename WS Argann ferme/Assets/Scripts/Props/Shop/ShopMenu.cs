using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField]
    private ShopBehaviour _shop;

    public void BuyApple()
    {
        if (this._shop.Inventory.MoneyHandler.MoneyCount >= this._shop.Inventory.InventoryV2Seeds[1].GetComponent<PlantBehaviour>().PlantData.Cost)
        {
            this._shop.Inventory.UpdateAmount(1, 1);
            this._shop.Inventory.MoneyHandler.UpdateMoneyCount(-this._shop.Inventory.InventoryV2Seeds[1].GetComponent<PlantBehaviour>().PlantData.Cost);
        }
    }

    public void BuyBanana()
    {
        if (this._shop.Inventory.MoneyHandler.MoneyCount >= this._shop.Inventory.InventoryV2Seeds[0].GetComponent<PlantBehaviour>().PlantData.Cost)
        {
            this._shop.Inventory.UpdateAmount(0, 1);
            this._shop.Inventory.MoneyHandler.UpdateMoneyCount(-this._shop.Inventory.InventoryV2Seeds[0].GetComponent<PlantBehaviour>().PlantData.Cost);
        }
    }

    public void BuyOrange()
    {
        if (this._shop.Inventory.MoneyHandler.MoneyCount >= this._shop.Inventory.InventoryV2Seeds[2].GetComponent<PlantBehaviour>().PlantData.Cost)
        {
            this._shop.Inventory.UpdateAmount(2, 1);
            this._shop.Inventory.MoneyHandler.UpdateMoneyCount(-this._shop.Inventory.InventoryV2Seeds[2].GetComponent<PlantBehaviour>().PlantData.Cost);
        }
    }

    public void QuitShopMenu()
    {
        this._shop.EventSystem.SetSelectedGameObject(null);
        this._shop.ShopMenuUI.SetActive(false);
        this._shop.PlayerInput.enabled = true;
    }
}

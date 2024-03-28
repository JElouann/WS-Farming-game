using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private ShopBehaviour _shop;

    public void BuyApple()
    {
        if (_shop._inventory.MoneyCount >= _shop._inventory.InventoryV2Seeds[1].GetComponent<PlantBehaviour>()._plantData.Cost)
        {
            _shop._inventory.UpdateAmount(1, 1);
            _shop._inventory.UpdateMoneyCount(-_shop._inventory.InventoryV2Seeds[1].GetComponent<PlantBehaviour>()._plantData.Cost);
            Debug.Log("Pomme achetée");
        }
    }

    public void BuyBanana()
    {
        if (_shop._inventory.MoneyCount >= _shop._inventory.InventoryV2Seeds[0].GetComponent<PlantBehaviour>()._plantData.Cost)
        {
            _shop._inventory.UpdateAmount(0, 1);
            _shop._inventory.UpdateMoneyCount(-_shop._inventory.InventoryV2Seeds[0].GetComponent<PlantBehaviour>()._plantData.Cost);
            Debug.Log("Banane achetée");
        }
    }

    public void BuyOrange()
    {
        if (_shop._inventory.MoneyCount >= _shop._inventory.InventoryV2Seeds[2].GetComponent<PlantBehaviour>()._plantData.Cost)
        {
            _shop._inventory.UpdateAmount(2, 1);
            _shop._inventory.UpdateMoneyCount(-_shop._inventory.InventoryV2Seeds[2].GetComponent<PlantBehaviour>()._plantData.Cost);
            Debug.Log("Banane achetée");
        }
        Debug.Log("Orange achetée");
    }

    public void QuitShopMenu()
    {
        _shop._gameObject.SetActive(false);
        _shop._playerInput.enabled = true;
    }
}

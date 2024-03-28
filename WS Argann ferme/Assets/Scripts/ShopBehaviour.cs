using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class ShopBehaviour : MonoBehaviour
{
    [field: SerializeField] public PlayerInventoryMain _inventory { get; private set; }
    [field: SerializeField] public PlayerInput _playerInput { get; private set; }
    private EventSystem _eventSystem;
    [field: SerializeField] public GameObject _gameObject {  get; private set; }
    [SerializeField] private GameObject _firstSelected;

    private void Awake()
    {
        _inventory = GameObject.Find("Player").GetComponent<PlayerInventoryMain>();
        _playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        _eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    public void OnInteract()
    {
        if (_inventory.CurrentFruitHold != null)
        {
            _inventory.UpdateMoneyCount(_inventory.CurrentFruitHold.GetComponent<PlantBehaviour>()._plantData.Gain);
            Destroy(_inventory.CurrentFruitHold);
            _inventory._inventoryDisplayer.UpdateHoldFruit(null);
        }
        else
        {
            ActiveShopMenu();
        }
    }

    private void ActiveShopMenu()
    {
        _gameObject.SetActive(true);
        _playerInput.enabled = false;
        _eventSystem.SetSelectedGameObject(_firstSelected);
    }
}

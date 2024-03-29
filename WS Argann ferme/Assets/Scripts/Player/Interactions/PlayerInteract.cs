using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private PlayerInput _playerInput;

    [SerializeField]
    private DetectInteractible _actionDetector;

    private PlayerInventoryMain _inventory;

    private void Awake()
    {
        this._playerInput = this.GetComponent<PlayerInput>();
        var inputHandler = this.GetComponent<PlayerInputHandler>();
        inputHandler.Interact += this.Interact;
        this._inventory = this.GetComponent<PlayerInventoryMain>();
    }

    /// <summary>
    /// This method is used to detect what object the player interacts with.
    /// </summary>
    private void Interact(InputAction.CallbackContext context)
    {
        GameObject interactionTarget = this._actionDetector.InteractionTarget;
        if (context.performed && interactionTarget != null)
        {
              switch (interactionTarget.tag)
              {
                case "Parcelle":
                    this.DecideParcelleAction(interactionTarget.GetComponent<Parcelle>().State, interactionTarget);
                    break;

                case "Shop":
                    interactionTarget.GetComponent<ShopBehaviour>().OnInteract();
                    break;

                case "JuiceMachine":
                    Debug.Log("JuiceMachine");
                    break;
            }
        }
    }

    /// <summary>
    /// This method is used to determine what action to do with the parcel depending on its current state.
    /// </summary>
    private void DecideParcelleAction(int currentParcelleState, GameObject parcelle)
    {
        switch (currentParcelleState)
        {
            case 0:
                this.gameObject.GetComponent<PlayerPlant>().Plant(parcelle, this.gameObject.GetComponent<PlayerInventoryMain>().GetSelectedSeed());
                break;

            case 1:
                this.gameObject.GetComponent<PlayerWater>().Water(parcelle);
                break;

            case 3:
                this.gameObject.GetComponent<PlayerHarvest>().Harvest(parcelle);
                break;

            default:
                break;
        }
    }
}

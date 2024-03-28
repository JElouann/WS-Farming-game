using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private PlayerInput _playerInput; //
    [SerializeField] private DetectInteractible _actionDetector;
    private PlayerInventoryMain _inventory;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>(); //
        var inputHandler = GetComponent<PlayerInputHandler>();
        inputHandler.Interact += Interact;
        _inventory = GetComponent<PlayerInventoryMain>();
    }

    private void Interact(InputAction.CallbackContext context)
    {
        GameObject interactionTarget = _actionDetector.InteractionTarget;
        if(context.performed && interactionTarget != null)
        {
              switch (interactionTarget.tag)
              {
                case "Parcelle":
                    DecideParcelleAction(interactionTarget.GetComponent<Parcelle>().State, interactionTarget);
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

    private void DecideParcelleAction(int currentParcelleState, GameObject parcelle)
    {
        switch (currentParcelleState)
        {
            case 0:
                gameObject.GetComponent<PlayerPlant>().Plant(parcelle, gameObject.GetComponent<PlayerInventoryMain>().GetSelectedSeed());
                break;

            case 1:
                gameObject.GetComponent<PlayerWater>().Water(parcelle);
                break;

            case 2:
                Debug.Log("growing");
                // Ultérieurement, faire afficher au dessus du perso un texte montrant l'impossibilité d'intéragir avec la plante en l'état
                break;
            case 3:
                gameObject.GetComponent<PlayerHarvest>().Harvest(parcelle);
                break;

            default:
                break;
        }
    }
}

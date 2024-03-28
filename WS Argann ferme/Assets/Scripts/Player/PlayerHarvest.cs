using UnityEngine;

public class PlayerHarvest : MonoBehaviour
{
    private PlayerInventoryMain _inventory;

    private void Awake()
    {
        _inventory = GetComponent<PlayerInventoryMain>();
    }

    public void Harvest(GameObject parcelle)
    {
        if (_inventory.CurrentFruitHold == null)
        {
            parcelle.GetComponent<Parcelle>().State = 0;
            _inventory.ChangeHoldFruit(parcelle.GetComponent<Parcelle>().ContainedPlant);
            parcelle.GetComponent<MeshRenderer>().material = parcelle.GetComponent<Parcelle>().DryDirtMat;
            parcelle.GetComponent<Parcelle>().ContainedPlant.SetActive(false);
            parcelle.GetComponent<Parcelle>().ContainedPlant = null;
        }
        else
        {
            Debug.Log("Fruit déjà en main");
        }
    }
    
}

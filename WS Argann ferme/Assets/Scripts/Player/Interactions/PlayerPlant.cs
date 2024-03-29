using UnityEngine;

public class PlayerPlant : MonoBehaviour
{
    private PlayerInventoryMain _inventory;

    /// <summary>
    /// This method instantiates a certain plant in a specific parcel and handles the changes in the inventory it implies.
    /// </summary>
    public void Plant(GameObject parcelle, GameObject plant)
    {
        if (this._inventory.InventoryV2Amounts[this.gameObject.GetComponent<PlayerInventoryMain>().GetSelectedSeedIndex()] > 0)
        {
            GameObject newPlant = Instantiate(plant, new Vector3(parcelle.transform.position.x, parcelle.transform.position.y + 0.15f, parcelle.transform.position.z), Quaternion.identity, null);
            newPlant.transform.localScale = Vector3.one * 3;
            parcelle.GetComponent<Parcelle>().ContainedPlant = newPlant;
            parcelle.GetComponent<Parcelle>().ContainedPlant.GetComponent<PlantBehaviour>().Parcelle = parcelle;
            this._inventory.UpdateAmount(this.gameObject.GetComponent<PlayerInventoryMain>().GetSelectedSeedIndex(), -1);
            parcelle.GetComponent<Parcelle>().State++;
        }
    }

    private void Awake()
    {
        this._inventory = this.GetComponent<PlayerInventoryMain>();
    }
}

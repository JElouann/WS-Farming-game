using UnityEngine;

public class PlayerHarvest : MonoBehaviour
{
    private PlayerInventoryMain _inventory;

    /// <summary>
    /// This method empties the targeted parcel and stocks the harvested fruit in the player's "hold slot". Also reset the targeted parcel.
    /// </summary>
    public void Harvest(GameObject parcelle)
    {
        if (this._inventory.CurrentFruitHold == null)
        {
            parcelle.GetComponent<Parcelle>().State = 0;
            this._inventory.ChangeHoldFruit(parcelle.GetComponent<Parcelle>().ContainedPlant);
            parcelle.GetComponent<MeshRenderer>().material = parcelle.GetComponent<Parcelle>().DryDirtMat;
            parcelle.GetComponent<Parcelle>().ContainedPlant.SetActive(false);
            parcelle.GetComponent<Parcelle>().ContainedPlant = null;
        }
        else
        {
            Debug.Log("Fruit déjà en main");
        }
    }

    private void Awake()
    {
        this._inventory = this.GetComponent<PlayerInventoryMain>();
    }
}

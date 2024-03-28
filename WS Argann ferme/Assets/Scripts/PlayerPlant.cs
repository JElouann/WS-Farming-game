using UnityEngine;

public class PlayerPlant : MonoBehaviour
{
    private PlayerInventoryMain _inventory;

    private void Awake()
    {
        _inventory = GetComponent<PlayerInventoryMain>();
    }

    public void Plant(GameObject parcelle, GameObject plant)
    {
        if (_inventory.InventoryV2Amounts[gameObject.GetComponent<PlayerInventoryMain>().GetSelectedSeedIndex()] > 0)
        {
            GameObject newPlant = Instantiate(plant, new Vector3(parcelle.transform.position.x, parcelle.transform.position.y + 0.15f, parcelle.transform.position.z), Quaternion.identity, null);
            newPlant.transform.localScale = Vector3.one * 3;
            parcelle.GetComponent<Parcelle>().ContainedPlant = newPlant;
            parcelle.GetComponent<Parcelle>().ContainedPlant.GetComponent<PlantBehaviour>().Parcelle = parcelle;
            _inventory.UpdateAmount(gameObject.GetComponent<PlayerInventoryMain>().GetSelectedSeedIndex(), -1);
            parcelle.GetComponent<Parcelle>().State++;
        }
        else
        {
            Debug.Log("Pas assez de graines");
        }
    }
}

using UnityEngine;

public class PlayerWater : MonoBehaviour
{
    /// <summary>
    /// This method increases the state of a parcel, changes his material and start the coroutine that makes its plant grow.
    /// </summary>
    public void Water(GameObject parcelle)
    {
        parcelle.GetComponent<Parcelle>().State++;
        parcelle.GetComponent<MeshRenderer>().material = parcelle.GetComponent<Parcelle>().WetDirtMat;
        this.StartCoroutine(parcelle.GetComponent<Parcelle>().ContainedPlant.GetComponent<PlantBehaviour>().Grow());
    }
}

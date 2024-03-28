using UnityEngine;

public class PlayerWater : MonoBehaviour
{
    public void Water(GameObject parcelle)
    {
        parcelle.GetComponent<Parcelle>().State++;
        parcelle.GetComponent<MeshRenderer>().material = parcelle.GetComponent<Parcelle>().WetDirtMat;
        parcelle.GetComponent<Parcelle>().ContainedPlant.GetComponent<PlantBehaviour>().StartGrowing();
    }
}

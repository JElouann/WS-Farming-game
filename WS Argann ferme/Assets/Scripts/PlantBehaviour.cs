using System.Collections;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{
    [field: SerializeField]
    public SeedData PlantData { get; private set; }

    [field: SerializeField]
    public GameObject Parcelle { get; set; }

    public bool IsGrowing { get; private set; }

    /// <summary>
    /// This coroutine makes the plant grow progressively by increasing its scale over the time. Increases its parcel state in the end.
    /// </summary>
    public IEnumerator Grow()
    {
        if (!this.IsGrowing)
        {
            this.IsGrowing = true;
            for (int stepCounter = 0; stepCounter < this.PlantData.NumberOfGrowthStep; stepCounter++)
            {
                yield return new WaitForSeconds(this.PlantData.TimeBetweenGrowthStep);
                this.gameObject.transform.localScale += new Vector3(this.PlantData.GrowthScaleStep, this.PlantData.GrowthScaleStep, this.PlantData.GrowthScaleStep);
            }

            this.Parcelle.GetComponent<Parcelle>().State++;
        }

        yield return null;
    }
}

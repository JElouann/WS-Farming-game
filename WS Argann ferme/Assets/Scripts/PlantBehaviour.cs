using System.Collections;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{
    [field: SerializeField] public SeedData _plantData {  get; private set; }
    [field: SerializeField] public GameObject Parcelle {  get; set; }
    public bool isGrowing {  get; private set; }
    public bool _canBeHarvested { get; private set; }

   public void StartGrowing()
    {
        
        StartCoroutine(Grow());
    }

   private IEnumerator Grow()
   {
        Debug.Log("call");
        if (!isGrowing)
        {
            isGrowing = true;
        Debug.Log("Started growing");
        for (int stepCounter = 0; stepCounter < _plantData.NumberOfGrowthStep; stepCounter++)
        {
                yield return new WaitForSeconds(_plantData.TimeBetweenGrowthStep);
                this.gameObject.transform.localScale += new Vector3(_plantData.GrowthScaleStep, _plantData.GrowthScaleStep, _plantData.GrowthScaleStep);
           
        }
            Parcelle.GetComponent<Parcelle>().State++;
            Debug.Log("finished growing");
        }
        
        yield return null;
   }
}

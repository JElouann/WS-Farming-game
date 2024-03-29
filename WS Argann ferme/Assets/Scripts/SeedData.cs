using UnityEngine;

[CreateAssetMenu(fileName = "Seed", menuName = "ScriptableObject/Seed", order = 1)]
public class SeedData : ScriptableObject
{
    [Header("Diverse")]
    [field: SerializeField]
    public string Name;
    [SerializeField]
    public MeshRenderer Mesh;
    [Header("Stats")]
    [SerializeField]
    public int Cost;
    [SerializeField]
    public int Gain;
    [Header("Growth parameters")]
    [SerializeField]
    public float TimeBetweenGrowthStep;
    [SerializeField]
    public int NumberOfGrowthStep;
    [SerializeField]
    public float GrowthScaleStep;
}

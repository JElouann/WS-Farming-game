using UnityEngine;

[CreateAssetMenu(fileName = "Seed", menuName = "ScriptableObject/Seed", order = 1)]
public class SeedData : ScriptableObject
{
    [Header("Diverse")]
    public string Name;
    public MeshRenderer Mesh;
    [Header("Stats")]
    public int Cost;
    public int Gain;
    [Header("Growth parameters")]
    public float TimeBetweenGrowthStep;
    public int NumberOfGrowthStep;
    public float GrowthScaleStep;
}

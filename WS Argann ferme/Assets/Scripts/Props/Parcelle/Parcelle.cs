using UnityEngine;

public class Parcelle : MonoBehaviour
{
    [field: SerializeField]
    public GameObject ContainedPlant { get; set; }

    [field: Range(0, 3)]
    public int State { get; set; }

    [field: SerializeField]
    public Material DryDirtMat { get; set; }

    [field: SerializeField]
    public Material WetDirtMat { get; set; }

    public MeshRenderer MeshRenderer { get; set; }

    private void Awake()
    {
        this.MeshRenderer = this.GetComponent<MeshRenderer>();
    }
}

using UnityEngine;

public class DetectInteractible : MonoBehaviour
{
    public GameObject InteractionTarget { get; private set; }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Wall" && (other.gameObject.tag == "Parcelle" || other.gameObject.tag == "Shop" || other.gameObject.tag == "JuiceMachine"))
        {
            InteractionTarget = other.gameObject;
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Wall" && (other.gameObject.tag == "Parcelle" || other.gameObject.tag == "Shop" || other.gameObject.tag == "JuiceMachine"))
        {
            InteractionTarget = null;
        }
    } 
}

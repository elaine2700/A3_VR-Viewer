using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Custominteraction : MonoBehaviour
{
    public Rigidbody[] rigidbodies;
    private void Awake()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(AddImpulse);

    }
 
    public void AddImpulse(HoverEnterEventArgs args)
    {
        foreach(var rb in rigidbodies)
        {
            rb.AddForce(Vector3.up *10, ForceMode.Impulse);
        }
    }
}

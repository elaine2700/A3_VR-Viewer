using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomInteractions : MonoBehaviour
{
    public Transform nameobject;
    private string name;
    public RaycastHit hitl;
    public RaycastHit hitr;
    public XRRayInteractor right;
    public XRRayInteractor left;
    private void Awake()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Sethovertrue);
        interactable.hoverExited.AddListener(Sethoverfalse);
        name = nameobject.name;
    }

    private void Sethovertrue(HoverEnterEventArgs args)
    {
        bool hitboolright = false;
        hitboolright = right.TryGetCurrent3DRaycastHit(out hitr);
        if (hitboolright)
        {
            Debug.Log("HIT BY RIGHT");
            Eventsmanager.current.Hoverright(name);
        }

        bool hitbooleft = false;
        hitbooleft = left.TryGetCurrent3DRaycastHit(out hitl);
        if (hitbooleft)
        {
            Debug.Log("HIT BY LEFT");
            Eventsmanager.current.Hoverleft(name);
        }
        if (hitboolright && hitbooleft)
        {
            Debug.Log("HIT BY Both");
            Eventsmanager.current.Hoverright(name);
            Eventsmanager.current.Hoverleft(name);
        }
    }
    private void Sethoverfalse(HoverExitEventArgs args)
    {
        bool hitboolright = true;
        hitboolright = right.TryGetCurrent3DRaycastHit(out hitr);
        if (!hitboolright)
        {
            Debug.Log("EXITED BY RIGHT");
            Eventsmanager.current.Hoverexitright(name);
        }

        bool hitbooleft = true;
        hitbooleft = left.TryGetCurrent3DRaycastHit(out hitl);
        if (!hitbooleft)
        {
            Debug.Log("EXITED BY LEFT");
            Eventsmanager.current.Hoverexitleft(name);
        }
        if (!hitboolright && !hitbooleft)
        {
            Debug.Log("EXITED BY Both");
            Eventsmanager.current.Hoverexitright(name);
            Eventsmanager.current.Hoverexitleft(name);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Views : MonoBehaviour
{
    [SerializeField] InputActionReference toggleReference;
    [SerializeField] GameObject nameDescriptionCanvas;

    public bool explodedViewActive;
    public List<BikePart> bikeParts = new List<BikePart>();

    private void Awake()
    {
        toggleReference.action.started += ToggleView;
        explodedViewActive = true;
    }

    void Start()
    {
        BikePart[] bikeComps = FindObjectsOfType<BikePart>();
        foreach (BikePart bikePart in bikeComps)
        {
            bikeParts.Add(bikePart);
        }
        Toggle();
        nameDescriptionCanvas.SetActive(false);
    }

    void ToggleView(InputAction.CallbackContext context)
    {
        Toggle();
    }

    // Called by UI button
    public void Toggle()
    {
        explodedViewActive = !explodedViewActive;
        TogglePos();
    }

    void TogglePos()
    {
        foreach(BikePart bikePart in bikeParts)
        {
            bikePart.TogglePos(explodedViewActive);
            /*Vector3 newPos = Vector3.zero;
            if (explodedViewActive)
            {
                newPos = bikePart.GetExplodedPos().position;
            }
            else
            {
                newPos = bikePart.GetInitialPosition().position;
            }
            Debug.Log(newPos);
            bikePart.transform.position = newPos;
            */
        }
    }

}

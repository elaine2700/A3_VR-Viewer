using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Views : MonoBehaviour
{
    [SerializeField] InputActionReference toggleReference;
    [SerializeField] GameObject bikeStandardView;
    [SerializeField] GameObject bikeExplodedView;

    public bool explodedViewActive;

    private void Awake()
    {
        toggleReference.action.started += ToggleView;
        explodedViewActive = true;
    }

    void Start()
    {
        Toggle();
    }

    void ToggleView(InputAction.CallbackContext context)
    {
        Toggle();
    }

    // Called by UI button
    public void Toggle()
    {
        explodedViewActive = !explodedViewActive;
        bikeStandardView.SetActive(!explodedViewActive);
        bikeExplodedView.SetActive(explodedViewActive);
    }

}

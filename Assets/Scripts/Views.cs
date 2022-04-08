using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Views : MonoBehaviour
{
    [SerializeField] InputActionReference toggleReference;
    [SerializeField] GameObject bikeStandardView;
    [SerializeField] GameObject bikeExplodedView;

    private void Awake()
    {
        toggleReference.action.started += ToggleView;
    }

    void Start()
    {
        bikeStandardView.SetActive(true);
        bikeExplodedView.SetActive(!bikeStandardView.activeSelf);
    }

    void ToggleView(InputAction.CallbackContext context)
    {
        bikeStandardView.SetActive(!bikeStandardView.activeSelf);
        bikeExplodedView.SetActive(!bikeStandardView.activeSelf);
    }

}

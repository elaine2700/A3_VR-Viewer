using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ExplodedView : MonoBehaviour
{
    public GameObject InfoCanvas;
    public TextMeshProUGUI NameField;
    public TextMeshProUGUI DescriptionField;

    public Toggle toggleNames;
    [SerializeField] InputActionReference displayNamesReference;
    
    public List<Names> bikePartSigns = new List<Names>();
    Views views;

    private void Awake()
    {
        displayNamesReference.action.started += ShowNamesWithButton;
        views = GetComponent<Views>();
    }

    private void Start()
    {
        FindNames();
    }

    void FindNames()
    {
        Names[] parts = FindObjectsOfType<Names>();
        foreach(Names part in parts)
        {
            bikePartSigns.Add(part);
        }
    }

    // Starts with input (Y button).
    void ShowNamesWithButton(InputAction.CallbackContext context)
    {
        toggleNames.isOn = !toggleNames.isOn;
        ShowAllNames();
    }

    public void ShowAllNames()
    {
        if (!views.explodedViewActive)
        {
            views.Toggle();
        }
        if (views.explodedViewActive)
        {
            foreach (Names bikePart in bikePartSigns)
            {
                bikePart.DisplayName(toggleNames.isOn);
            }
        }
    }




}

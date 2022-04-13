using System.Collections;
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
    [SerializeField] InputActionReference toggleNamesReference;


    public List<BikePart> bikePartSigns = new List<BikePart>();
    Views views;
    bool showNames;

    private void Awake()
    {
        toggleNamesReference.action.started += ShowNamesWithButton;
        views = GetComponent<Views>();
        
    }

    private void Start()
    {
        FindNames();
        showNames = false;
    }

    void FindNames()
    {
        BikePart[] parts = FindObjectsOfType<BikePart>();
        //Debug.Log(parts.Length);
        foreach(BikePart part in parts)
        {
            bikePartSigns.Add(part);
        }
    }

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
        showNames = toggleNames.isOn;
        foreach(BikePart bikePart in bikePartSigns)
        {
            bikePart.ShowName(showNames);
        }
    }


}

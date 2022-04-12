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


    public List<TextMeshPro> bikePartSigns = new List<TextMeshPro>();
    Views views;
    bool showNames;

    private void Awake()
    {
        toggleNamesReference.action.started += ShowNamesWithButton;
    }

    private void Start()
    {
        views = GetComponent<Views>();
        FindNames();
        showNames = false;
    }

    void FindNames()
    {
        BikePart[] parts = FindObjectsOfType<BikePart>();
        foreach(BikePart part in parts)
        {
            TextMeshPro namePart = part.gameObject.GetComponentInChildren<TextMeshPro>();
            if(namePart != null)
            {
                bikePartSigns.Add(namePart);
            }
        }
    }

    void ShowNamesWithButton(InputAction.CallbackContext context)
    {
        ShowAllNames();
        toggleNames.isOn = !toggleNames.isOn;
    }

    public void ShowAllNames()
    {
        if (!views.explodedViewActive)
        {
            views.Toggle();
        }
        showNames = toggleNames.isOn;
        foreach(TextMeshPro nameText in bikePartSigns)
        {
            nameText.gameObject.SetActive(showNames);
        }
    }
}

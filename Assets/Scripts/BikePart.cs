using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class BikePart : XRBaseInteractable
{
    [SerializeField] string partName;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] TextMeshProUGUI nameField; // todo make prefab

    ExplodedView explodedView;


    private void Start()
    {
        explodedView = FindObjectOfType<ExplodedView>();
    }

    public void DisplayInfo()
    {
        // ToDo separate name from description
        // ToDo show name next to component position
        // ToDo Description box next to bike
        explodedView.InfoCanvas.SetActive(true);
        explodedView.NameField.text = partName;
        explodedView.DescriptionField.text = description;
        Debug.Log(partName);
        Debug.Log(description);
    }

    public void HideInfo()
    {
        explodedView.InfoCanvas.SetActive(false);
    }

}

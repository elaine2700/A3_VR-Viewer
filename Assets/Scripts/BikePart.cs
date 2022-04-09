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
    [SerializeField] GameObject infoCanvas;
    [SerializeField] TextMeshProUGUI nameField;
    [SerializeField] TextMeshProUGUI descriptionField;



    private void Start()
    {
        //infoCanvas = GameObject.Find("Name-Description Canvas");
        //nameField = infoCanvas.transform.Find("Part Name Text").GetComponent<TextMeshProUGUI>();
        //descriptionField = infoCanvas.transform.Find("Description Text").GetComponent<TextMeshProUGUI>();
    }

    public void DisplayInfo()
    {
        infoCanvas.SetActive(true);
        nameField.text = partName;
        descriptionField.text = description;
        Debug.Log(partName);
        Debug.Log(description);
    }

    public void HideInfo()
    {
        infoCanvas.SetActive(false);
    }

}

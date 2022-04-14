using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class BikePart : XRBaseInteractable
{
    
    [SerializeField] Transform explodedTransform;
    [SerializeField] string partName;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] Names nameField;

    ExplodedView explodedView;
    MeshRenderer meshRenderer;
    Views views;
    TextMeshPro nameDisplay;
    Transform initialTransform;

    Vector3 initialPos;
    Vector3 explodedPos;

    private void Start()
    {
        initialTransform = transform;
        initialPos = transform.position;
        initialTransform.TransformPoint(initialPos);
        explodedTransform.TransformPoint(explodedPos);
        meshRenderer = GetComponent<MeshRenderer>();
        views = FindObjectOfType<Views>();
        nameDisplay = nameField.GetComponent<TextMeshPro>();
        explodedView = FindObjectOfType<ExplodedView>();
        nameDisplay.text = partName;
    }

    // Function called by On Hover Enter event.
    public void DisplayInfo()
    {
        if (views.explodedViewActive)
        {
            HighlightPart(true);
            explodedView.NameField.text = partName;
            explodedView.DescriptionField.text = description;
            ShowName(true);
            explodedView.InfoCanvas.SetActive(true);
        }
    }

    // Function called by On Hover Exit event.
    public void HideInfo()
    {
        if (views.explodedViewActive)
        {
            HighlightPart(false);
            explodedView.InfoCanvas.SetActive(false);
            ShowName(false);
        }    
    }

    private void HighlightPart(bool highlight)
    {
        Color newColor = Color.green;
        if (highlight)
        {
            newColor = Color.red;
        }
        else
        {
            newColor = Color.white;
        }
        meshRenderer.material.color = newColor;
    }

    public void ShowName(bool show)
    {
        nameField.DisplayName(show);
    }

    public void TogglePos(bool explodedView)
    {
        if(explodedView == true)
        {
            transform.position = explodedTransform.position;
        }
        else
        {
            ShowName(false);
            transform.position = initialPos;
        }
    }

}

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

    bool showName = true;

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

    public void DisplayInfo()
    {
        if (views.explodedViewActive)
        {
            HighlightPart();
            explodedView.NameField.text = partName;
            explodedView.DescriptionField.text = description;
            ShowName(true);
            explodedView.InfoCanvas.SetActive(true);
        }
    }

    public void HideInfo()
    {
        if (views.explodedViewActive)
        {
            UnhighlightPart();
            explodedView.InfoCanvas.SetActive(false);
            
            ShowName(showName);
        }    
    }

    private void HighlightPart()
    {
        meshRenderer.material.color = Color.red;
    }

    private void UnhighlightPart()
    {
        meshRenderer.material.color = Color.white;
    }

    public void ShowName(bool show)
    {
        if (views.explodedViewActive)
        {
            nameField.DisplayName(show);
        }
    }

    public void SetShowName(bool show)
    {
        showName = show;
    }

    public Transform GetInitialPosition()
    {
        return initialTransform;
    }

    public Transform GetExplodedPos()
    {
        return explodedTransform;
    }

    public void TogglePos(bool explodedView)
    {
        if(explodedView)
        {
            transform.position = explodedTransform.position;
        }
        else
        {

            transform.position = initialPos;
        }
    }

}
